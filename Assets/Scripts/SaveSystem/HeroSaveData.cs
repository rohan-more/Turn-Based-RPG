using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeroSaveData
{
    public string heroName;
    public string isUnlocked;
    public string isSelected;
    public int attackPower;
    public int level;
    public int xP;
    public int health;
    public HeroSaveData()
    {

    }

    public HeroSaveData(RPG.HeroData heroData)
    {
        this.heroName = heroData.heroName.ToString();
        this.isUnlocked = heroData.isLocked.ToString();
        this.isSelected = heroData.isSelected.ToString();
        this.attackPower = heroData.attackPower;
        this.level = heroData.level;
        this.xP = heroData.xP;
        this.health = heroData.maxHealth;
    }
}


