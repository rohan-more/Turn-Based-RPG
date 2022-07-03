using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadHeroStats : MonoBehaviour
{
    public RPG.HeroData heroData;
    void Start()
    {
        ReadSavedStats();
        LoadStatsToPopup();
    }
    public void ReadSavedStats()
    {
        SaveSystem.ReadSaveFile(heroData);
    }

    public void LoadStatsToPopup()
    {
        SaveSystem.LoadSaveFile(heroData.name);
    }

}
