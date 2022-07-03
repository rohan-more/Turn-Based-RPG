using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroController : MonoBehaviour
{
    [SerializeField]
    private RPG.HeroData heroData;
    [SerializeField]
    private Image heroImage; 

[SerializeField]
    private RPG_UI.DamageController damageController;
    [SerializeField]
    private HeroImageButton heroImageController;

    // Start is called before the first frame update
    void Start()
    {
        heroImageController.character = heroData.heroName;
        heroImage.sprite = heroData.heroSprite;
    }
}
