using System.Collections;
using System.Collections.Generic;
using System;
using RPG;

public static class ScoreManager
{
    private static HeroSaveData saveData;
    public static void ReadSaveFile(CharacterData.CharacterName name)
    {
        saveData = SaveSystem.ReadHeroFile(name.ToString());
    }

    public static void WriteSaveFile()
    {
        SaveSystem.WriteSaveFile(saveData);
    }
    public static void UpdateStats(CharacterData.CharacterName name)
    {
        ReadSaveFile(name);
        saveData.xP++;
        WriteSaveFile();
    }
    public static void UpdateLevel(CharacterData.CharacterName name)
    {
        ReadSaveFile(name);
        if (saveData.xP % HeroUnlockManager.LEVEL_UP_COUNT == 0)
        {
            saveData.level++;
            saveData.xP = Convert.ToInt32(saveData.xP * 1.1);
            saveData.health = Convert.ToInt32(saveData.health * 1.1);
            WriteSaveFile();
        }
    }


}
