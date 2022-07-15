using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER_PATH = Application.persistentDataPath + "/SaveData/";
    private static void WriteTextToFile(string path, string json)
    {
        File.WriteAllText(path, json);
    }

    private static HeroSaveData DeserializeHeroData(string path)
    {
        using StreamReader r = new StreamReader(path);
        string json = r.ReadToEnd();
        HeroSaveData heroData = JsonConvert.DeserializeObject<HeroSaveData>(json);
        return heroData;
    }

    public static void CreateSaveFile(RPG.HeroData heroData)
    {
        if (!Directory.Exists(SAVE_FOLDER_PATH))
        {
            Directory.CreateDirectory(SAVE_FOLDER_PATH);
        }
        string path = SAVE_FOLDER_PATH + heroData.heroName + ".json";
        if (File.Exists(path))
        {
            return;
        }

        HeroSaveData saveData = new HeroSaveData(heroData);
        string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
        WriteTextToFile(path, json);
    }

    public static void LoadHeroSaveFile(RPG.HeroData heroData)
    {
        string path = SAVE_FOLDER_PATH + heroData.heroName + ".json";
        if (File.Exists(path))
        {
            if (heroData.isLocked == RPG.CharacterData.LockedState.LOCKED)
            {
                heroData.isLocked = RPG.CharacterData.LockedState.UNLOCKED;
            }
            HeroSaveData saveData = new HeroSaveData(heroData);
            string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
            WriteTextToFile(path, json);
        }
    }
    public static void LoadSaveFile(string name)
    {
        string path = SAVE_FOLDER_PATH + name + ".json";
        if (File.Exists(path) && !GameDataManager.Instance.HeroSavedData.ContainsKey(GetEnumFromString(name)))
        {
            GameDataManager.Instance.HeroSavedData.Add(GetEnumFromString(name), DeserializeHeroData(path));
        }
    }

    public static HeroSaveData LoadHeroSaveFile(string name)
    {
        string path = SAVE_FOLDER_PATH + name + ".json";
        if (File.Exists(path))
        {
            return DeserializeHeroData(path);
        }
        else
        {
            Debug.LogError(path + " not found!");
        }
        return null;
    }

    public static void WriteSaveFile(HeroSaveData saveData)
    {
        string path = SAVE_FOLDER_PATH + saveData.heroName + ".json";
        if (File.Exists(path))
        {
            string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
            File.WriteAllText(path, json);
        }
        else
        {
            Debug.LogError(path + " not found!");
        }
    }

    public static HeroSaveData ReadHeroFile(string name)
    {
        string path = SAVE_FOLDER_PATH + name + ".json";
        if (File.Exists(path))
        {
            using StreamReader r = new StreamReader(path);
            string json = r.ReadToEnd();
            HeroSaveData heroData = JsonConvert.DeserializeObject<HeroSaveData>(json);
            return heroData;
        }
        else
        {
            Debug.LogError(path + " not found!");
        }
        return null;
    }


    private static RPG.CharacterData.CharacterName GetEnumFromString(string name)
    {
        RPG.CharacterData.CharacterName heroName;
        if (Enum.TryParse(name, out heroName))
        {
            return heroName;
        }
        return RPG.CharacterData.CharacterName.LAMBERT;
    }


}
