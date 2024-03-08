using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RPG;
using UnityEngine.TextCore.Text;
public sealed class GameDataManager
{
    private GameDataManager() { }
    private static GameDataManager instance = null;
    public static GameDataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameDataManager();
            }
            return instance;
        }
    }

    public Dictionary<RPG.CharacterData.CharacterName,HeroSaveData> HeroSavedData = new Dictionary<RPG.CharacterData.CharacterName, HeroSaveData>();
    public List<RPG.CharacterData.CharacterName> SelectedHeroes = new List<RPG.CharacterData.CharacterName>();
    public Dictionary<RPG.CharacterData.CharacterName, bool> HeroLockStatus = new Dictionary<RPG.CharacterData.CharacterName, bool>();

    public RPG.CharacterData.CharacterName GetEnumFromString(string name)
    {
        RPG.CharacterData.CharacterName heroName;
        if (Enum.TryParse(name, out heroName))
        {
            return heroName;
        }
        return RPG.CharacterData.CharacterName.LAMBERT;
    }

    public HeroSaveData GetHeroData(RPG.CharacterData.CharacterName name)
    {
        HeroSaveData data = null;
        if (!string.IsNullOrEmpty(name.ToString()))
        {
            SaveSystem.LoadSaveFile(name.ToString());
            GameDataManager.Instance.HeroSavedData.TryGetValue(name, out data);
        }

        return data;
    }
}
