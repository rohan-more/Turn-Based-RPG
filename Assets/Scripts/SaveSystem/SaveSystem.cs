using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER_PATH = Application.persistentDataPath + "/SaveData/";

    public static void ReadSaveFile(RPG.HeroData heroData)
    {
        if (!Directory.Exists(SAVE_FOLDER_PATH))
        {
            Directory.CreateDirectory(SAVE_FOLDER_PATH);
        }
        string path = SAVE_FOLDER_PATH + heroData.heroName + ".json";
        if(File.Exists(path))
        {
            return;
        }

        HeroSaveData saveData = new HeroSaveData(heroData);
        string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    public static void LoadSaveFile(string name)
    {
        string path = SAVE_FOLDER_PATH + name + ".json";
        if (File.Exists(path) && !GameDataManager.Instance.heroDict.ContainsKey(GetEnumFromString(name)))
        {
            using StreamReader r = new StreamReader(path);
            string json = r.ReadToEnd();
            HeroSaveData heroData = JsonConvert.DeserializeObject<HeroSaveData>(json);
            GameDataManager.Instance.heroDict.Add(GetEnumFromString(name), heroData);
        }
    }

    public static HeroSaveData LoadHeroSaveFile(string name)
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
