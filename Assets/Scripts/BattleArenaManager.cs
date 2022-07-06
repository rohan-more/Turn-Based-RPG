using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.StateMachine;

public class BattleArenaManager : StateMachine
{
    #region State Functions
    State currentState;
    public PlayerTurn PlayerTurnState = new PlayerTurn();
    public BossTurn BossTurnState = new BossTurn();
    public PlayerDead PlayerDeadState = new PlayerDead();
    public PlayerWon PlayerWinState = new PlayerWon();
    public PlayerLost PlayerLoseState = new PlayerLost();
    #endregion

    [SerializeField]
    private List<RPG.HeroData> heroDataList;
    [SerializeField]
    private List<RPG.BossData> bossDataList;
    #region UI Elements
    private List<HeroController> heroControllers = new List<HeroController>();
    private List<HeroSaveData> heroSaveData = new List<HeroSaveData>();
    public HeroController hero1;
    public HeroController hero2;
    public HeroController hero3;
    public Toggle hero1Toggle;
    public Toggle hero2Toggle;
    public Toggle hero3Toggle;
    public BossController selectedBoss;
    [HideInInspector]
    public HeroController attackedHero;
    [HideInInspector]
    public HeroController attackingHero;
    #endregion
    private bool isPointerHeldDown;
    public RPG_UI.ResultsPopupManager popupManager;

    void Awake()
    {
        heroControllers.Add(hero1);
        heroControllers.Add(hero2);
        heroControllers.Add(hero3);
        SetupCharacters();
    }
    private void SetupCharacters()
    {
        foreach (var item in GameDataManager.Instance.SelectedHeroes)
        {
            heroSaveData.Add(SaveSystem.LoadHeroSaveFile(item.ToString()));
        }

        for (int i = 0; i < heroSaveData.Count; i++)
        {
            heroControllers[i].saveData = heroSaveData[i];
            heroControllers[i].heroData = GetHeroData(GameDataManager.Instance.GetEnumFromString(heroSaveData[i].heroName));
        }
        selectedBoss.bossData = bossDataList[Random.Range(0, bossDataList.Count)];
    }

    private void OnEnable()
    {
        EventManager.IsPointerHeldDown.AddListener(LoadPopupData);
        hero1Toggle.onValueChanged.AddListener(AttackBoss);
        hero2Toggle.onValueChanged.AddListener(AttackBoss);
        hero3Toggle.onValueChanged.AddListener(AttackBoss);
    }

    private void OnDisable()
    {
        EventManager.IsPointerHeldDown.AddListener(LoadPopupData);
        hero1Toggle.onValueChanged.RemoveListener(AttackBoss);
        hero2Toggle.onValueChanged.RemoveListener(AttackBoss);
        hero3Toggle.onValueChanged.RemoveListener(AttackBoss);
    }

    private void LoadPopupData(bool value)
    {
        isPointerHeldDown = value;
    }

    #region StateMachine Functions
    /// <summary>
    /// Player attacking boss
    /// </summary>
    /// <param name="value"></param>
    private void AttackBoss(bool value)
    {
        if (value && !isPointerHeldDown)
        {
            //Debug.Log("Begin");
            ChangeStateTo(PlayerTurnState);

            if (hero1Toggle.isOn)
            {
                attackingHero = hero1;
            }
            else if (hero2Toggle.isOn)
            {
                attackingHero = hero2;
            }
            else
            {
                attackingHero = hero3;
            }
            StartCoroutine(currentState.Attack(this, attackingHero.saveData.attackPower));

            foreach (var item in heroControllers)
            {
                item.heroToggle.isOn = item.heroToggle.interactable = false;
            }
        }
        isPointerHeldDown = false;
    }

    /// <summary>
    /// Boss attacks player
    /// </summary>
    /// <param name="value"></param>
    public void AttackPlayer()
    {
        attackedHero = heroControllers[Random.Range(0, heroControllers.Count)];
        StartCoroutine(currentState.Attack(this, selectedBoss.bossData.attackPower));
    }

    /// <summary>
    /// Set heroes active after boss's turn
    /// </summary>
    /// <param name="value"></param>
    public void ActivateHeroes()
    {
        foreach (var item in heroControllers)
        {
            item.heroToggle.interactable = true;
        }
    }

    /// <summary>
    /// Has player won?
    /// </summary>
    /// <param name="value"></param>

    public void HasPlayerWon(bool hasWon)
    {
        if (hasWon)
        {
            StartCoroutine(currentState.Win(this));
            foreach (var item in heroControllers)
            {
                ScoreManager.UpdateStats(item.heroName);
                ScoreManager.UpdateLevel(item.heroName);
            }
            StartCoroutine(popupManager.BattleState(true));
        }
        else
        {
            StartCoroutine(currentState.Lose(this));
            StartCoroutine(popupManager.BattleState(false));
        }
        HeroUnlockManager.UpdateBattleCount();
    }

    /// <summary>
    /// Is hero dead?
    /// </summary>
    /// <param name="value"></param>

    public void HeroDeath()
    {
        StartCoroutine(currentState.Death(this));
        if (heroControllers.Count > 0)
        {
            heroControllers.Remove(attackedHero);
        }

        if (heroControllers.Count == 0)
        {
            ChangeStateTo(PlayerLoseState);
            HasPlayerWon(false);
        }
    }

    public void ChangeStateTo(State newState)
    {
        currentState = newState;
    }
    #endregion

    private RPG.HeroData GetHeroData(RPG.CharacterData.CharacterName heroName)
    {
        foreach (var item in heroDataList)
        {
            if (item.heroName == heroName)
            {
                return item;
            }
        }
        return null;
    }
}
