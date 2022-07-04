using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG;

public class BattleArenaManager : MonoBehaviour
{
    [SerializeField]
    private List<HeroController> heroControllers = new List<HeroController>();
    private List<HeroSaveData> heroSaveData = new List<HeroSaveData>();
    private HeroController hero1;
    private HeroController hero2;
    private HeroController hero3;

    [SerializeField]
    private List<RPG.HeroData> heroDataList;
    void Awake()
    {
        hero1 = heroControllers[0];
        hero2 = heroControllers[1];
        hero3 = heroControllers[2];
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

    private RPG.HeroData GetHeroData(RPG.CharacterData.CharacterName heroName)
    {
        foreach (var item in heroDataList)
        {
            if(item.heroName == heroName)
            {
                return item;
            }
        }
        return null;
    }

    




}
