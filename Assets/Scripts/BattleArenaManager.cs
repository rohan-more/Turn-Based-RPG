using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.StateMachine;

public class BattleArenaManager : StateMachine
{
    State currentState;
    public PlayerTurn PlayerTurnState = new PlayerTurn();
    public BossTurn BossTurnState = new BossTurn();
    [SerializeField]
    private List<RPG.HeroData> heroDataList;
    #region UI Elements
    private List<HeroController> heroControllers = new List<HeroController>();
    private List<HeroSaveData> heroSaveData = new List<HeroSaveData>();
    public HeroController hero1;
    public HeroController hero2;
    public HeroController hero3;
    public Toggle hero1Toggle;
    public Toggle hero2Toggle;
    public Toggle hero3Toggle;
    public BossController boss;
    [HideInInspector]
    public HeroController selectedHero;
    #endregion

    void Awake()
    {
        heroControllers.Add(hero1);
        heroControllers.Add(hero2);
        heroControllers.Add(hero3);

        // ------------- Temp allocation - NEEDS TO BE REMOVED ------------//
        GameDataManager.Instance.SelectedHeroes.Add(RPG.CharacterData.CharacterName.LAMBERT);
        GameDataManager.Instance.SelectedHeroes.Add(RPG.CharacterData.CharacterName.ESKEL);
        GameDataManager.Instance.SelectedHeroes.Add(RPG.CharacterData.CharacterName.VESEMIR);

        foreach (var item in GameDataManager.Instance.SelectedHeroes)
        {
            heroSaveData.Add(SaveSystem.LoadHeroSaveFile(item.ToString()));
        }

        for (int i = 0; i < heroSaveData.Count; i++)
        {
            heroControllers[i].saveData = heroSaveData[i];
            heroControllers[i].heroData = GetHeroData(GameDataManager.Instance.GetEnumFromString(heroSaveData[i].heroName));
        }
    }

    private void OnEnable()
    {
        hero1Toggle.onValueChanged.AddListener(AttackBoss);
        hero2Toggle.onValueChanged.AddListener(AttackBoss);
        hero3Toggle.onValueChanged.AddListener(AttackBoss);
    }

    private void OnDisable()
    {
        hero1Toggle.onValueChanged.RemoveListener(AttackBoss);
        hero2Toggle.onValueChanged.RemoveListener(AttackBoss);
        hero3Toggle.onValueChanged.RemoveListener(AttackBoss);
    }

    private void AttackBoss(bool value)
    {
        if (value)
        {
            //Debug.Log("Begin");
            ChangeStateTo(PlayerTurnState);
            selectedHero = heroControllers[Random.Range(0, heroControllers.Count)];
            StartCoroutine(currentState.Attack(this, selectedHero.saveData.attackPower));
            StartCoroutine(currentState.Attack(this, boss.attackPower));
            hero1Toggle.isOn = hero2Toggle.isOn = hero3Toggle.isOn = false;
        }
    }

    public void AttackPlayer()
    {
        StartCoroutine(currentState.Attack(this, boss.attackPower));
    }

    public void ChangeStateTo(State newState)
    {
        currentState = newState;
    }


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
