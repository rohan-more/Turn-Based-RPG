using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [HideInInspector]
    public RPG.BossData bossData;
    [SerializeField]
    private TMPro.TMP_Text nameText;
    [SerializeField]
    private RPG_UI.DamageController damageController;
    [SerializeField]
    private RPG_UI.HealthBarController healthBarController;
    [HideInInspector]
    public int currentHealth;
    void Start()
    {
        currentHealth = bossData.maxHealth;
        nameText.text = bossData.name;
        healthBarController.SetMaxHealth(bossData.maxHealth);
    }

    public void DoDamage(int damage)
    {
        damageController.DealDamage(damage);
        currentHealth = healthBarController.GetCurrentHealth();
    }

}
