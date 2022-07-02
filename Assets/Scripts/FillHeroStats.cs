using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillHeroStats : MonoBehaviour
{
    [SerializeField]
    private Image heroImage;
    [SerializeField]
    private TMPro.TMP_Text nameText;
    [SerializeField]
    private TMPro.TMP_Text levelText;
    [SerializeField]
    private TMPro.TMP_Text attackPowerText;

    public void UpdateStats(RPG.HeroData heroData)
    {
        heroImage.sprite = heroData.heroSprite;
        nameText.text = heroData.heroName.ToString();
        levelText.text = heroData.level.ToString();
        attackPowerText.text = heroData.attackPower.ToString();
    }

}
