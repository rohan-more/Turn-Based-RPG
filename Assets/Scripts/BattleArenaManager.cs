using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.StateMachine;

public class BattleArenaManager : MonoBehaviour
{
    [SerializeField]
    private bool isDebugMode;
    [SerializeField]
    private RPG.HeroList heroDataList;

    [SerializeField]
    private RPG.BossList bossDataList;
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
    [SerializeField]
    private BattleStateManager stateManager;

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

        if (isDebugMode)
        {
            GameDataManager.Instance.SelectedHeroes.Add(RPG.CharacterData.CharacterName.LAMBERT);
            GameDataManager.Instance.SelectedHeroes.Add(RPG.CharacterData.CharacterName.ESKEL);
            GameDataManager.Instance.SelectedHeroes.Add(RPG.CharacterData.CharacterName.VESEMIR);
        }

        for (int i = 0; i < heroSaveData.Count; i++)
        {
            heroControllers[i].saveData = heroSaveData[i];
            heroControllers[i].heroData = GetHeroData(GameDataManager.Instance.GetEnumFromString(heroSaveData[i].heroName));
        }
        selectedBoss.bossData = bossDataList.All[Random.Range(0, bossDataList.All.Count)];
        stateManager.boss = selectedBoss;
    }

    private void Start()
    {
        stateManager.AwaitingPlayerInput();
    }

    private void OnEnable()
    {
        EventManager.IsPointerHeldDown.AddListener(LoadPopupData);
        EventManager.EnableHeroToggles.AddListener(ActivateHeroes);
        EventManager.PlayerWon.AddListener(HasPlayerWon);
        EventManager.HeroDead.AddListener(HeroDeath);
        hero1Toggle.onValueChanged.AddListener(AttackBoss);
        hero2Toggle.onValueChanged.AddListener(AttackBoss);
        hero3Toggle.onValueChanged.AddListener(AttackBoss);
    }

    private void OnDisable()
    {
        EventManager.IsPointerHeldDown.RemoveListener(LoadPopupData);
        EventManager.EnableHeroToggles.RemoveListener(ActivateHeroes);
        EventManager.HeroDead.RemoveListener(HeroDeath);
        EventManager.PlayerWon.RemoveListener(HasPlayerWon);
        hero1Toggle.onValueChanged.RemoveListener(AttackBoss);
        hero2Toggle.onValueChanged.RemoveListener(AttackBoss);
        hero3Toggle.onValueChanged.RemoveListener(AttackBoss);
    }

    private void LoadPopupData(bool value)
    {
        isPointerHeldDown = value;
    }

    private void AttackBoss(bool value)
    {
        if (value && !isPointerHeldDown)
        {
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
            stateManager.attackingHero = attackingHero;
            stateManager.AttackBoss();
            ChooseRandomHeroToAttack();
            foreach (var item in heroControllers)
            {
                item.heroToggle.isOn = item.heroToggle.interactable = false;
            }
        }
        isPointerHeldDown = false;

    }

    public void HasPlayerWon(bool hasWon)
    {
        if (hasWon)
        {
            foreach (var item in heroControllers)
            {
                ScoreManager.UpdateStats(item.heroName);
                ScoreManager.UpdateLevel(item.heroName);
            }
            StartCoroutine(popupManager.BattleState(true));
        }
        else
        {
            StartCoroutine(popupManager.BattleState(false));
        }
        if(!isDebugMode)
        {
            HeroUnlockManager.UpdateBattleCount();
        }
    }

    public void ChooseRandomHeroToAttack()
    {
        stateManager.attackedHero = attackedHero = heroControllers[Random.Range(0, heroControllers.Count)];
    }

    public void HeroDeath()
    {
        if (heroControllers.Count > 0)
        {
            heroControllers.Remove(attackedHero);
        }

        if (heroControllers.Count == 0)
        {
            stateManager.SetHeroDeathState();
            HasPlayerWon(false);
        }
    }

    public void ActivateHeroes()
    {
        foreach (var item in heroControllers)
        {
            item.heroToggle.interactable = true;
        }
    }


    private RPG.HeroData GetHeroData(RPG.CharacterData.CharacterName heroName)
    {
        foreach (var item in heroDataList.All)
        {
            if (item.heroName == heroName)
            {
                return item;
            }
        }
        return null;
    }
}
