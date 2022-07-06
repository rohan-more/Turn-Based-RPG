using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HeroUnlockManager
{
    public static int totalBattleCount;
    public static int heroesUnlockCount;
    public const int UNLOCK_HERO_COUNT = 5;
    public const int LEVEL_UP_COUNT = 5;

    public static void GetHeroUnlockedCount()
    {
        heroesUnlockCount = PlayerPrefs.GetInt("HeroesUnlocked");
    }

    public static void UpdateHeroUnlockedCount()
    {
        PlayerPrefs.SetInt("HeroesUnlocked", heroesUnlockCount++);
    }

    public static void UpdateBattleCount()
    {
        totalBattleCount++;
        PlayerPrefs.SetInt("BattleCount", totalBattleCount);
    }

    public static int GetBattleCount()
    {
        totalBattleCount = PlayerPrefs.GetInt("BattleCount");
        return totalBattleCount;
    }

    public static void CheckHeroStatus(RPG_UI.HeroSelector item)
    {
        HeroSaveData heroData = SaveSystem.LoadHeroSaveFile(item.heroData.heroName.ToString());
        if (heroData.isUnlocked == RPG.CharacterData.LockedState.LOCKED.ToString())
        {
            item.LockHero();
        }
        else
        {
            item.UnlockHero();
        }
    }
}
