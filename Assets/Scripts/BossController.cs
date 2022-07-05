using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public RPG.BossData bossData;
    [SerializeField]
    private RPG_UI.DamageController damageController;
    [SerializeField]
    private RPG_UI.HealthBarController healthBarController;
    public int currentHealth;
    void Start()
    {
        currentHealth = bossData.maxHealth;
        healthBarController.SetMaxHealth(bossData.maxHealth);
    }

    public void DoDamage(int damage)
    {
        damageController.DealDamage(damage);
        currentHealth = healthBarController.GetCurrentHealth();
    }

}
