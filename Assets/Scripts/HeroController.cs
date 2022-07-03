using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroController : MonoBehaviour
{
    public RPG.HeroData heroData;
    [SerializeField]
    private Image heroImage;
    public HeroSaveData saveData;
    [SerializeField]
    private RPG_UI.DamageController damageController;
    [SerializeField]
    private HeroImageButton heroImageController;

    void Start()
    {
        heroImageController.character = heroData.heroName;
        heroImage.sprite = heroData.heroSprite;
        LoadPopupData();
    }
    private void LoadPopupData()
    {
        EventManager.DisplayHeroStats.Invoke(saveData);
    }
}
