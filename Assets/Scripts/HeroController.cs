using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroController : MonoBehaviour
{
    public RPG.HeroData heroData;
    [SerializeField]
    private Image heroImage;
    [SerializeField]
    private TMPro.TMP_Text nameText;
    [HideInInspector]
    public HeroSaveData saveData;
    [SerializeField]
    private RPG_UI.DamageController damageController;
    [SerializeField]
    private HeroImageButton heroImageController;
    [SerializeField]
    private RPG_UI.HealthBarController healthBarController;
    [HideInInspector]
    public int currentHealth;
    public Toggle heroToggle;
    [SerializeField]
    private Image deadOverlay;
    public RPG.CharacterData.CharacterName heroName;
    void Start()
    {
        heroImageController.GetHeroData(heroData.heroName);
        heroName = heroData.heroName;
        nameText.text = heroData.heroName.ToString();
        heroImage.sprite = heroData.heroSprite;
        currentHealth = healthBarController.GetMaxHealth();
        healthBarController.SetMaxHealth(heroData.maxHealth);
    }

    public void DoDamage(int damage)
    {
        damageController.DealDamage(damage);
        currentHealth = healthBarController.GetCurrentHealth();
    }

    public void DisableHero()
    {
        deadOverlay.gameObject.SetActive(true);
        heroToggle.interactable = false;
    }
}
