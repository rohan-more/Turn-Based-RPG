using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]
    private RPG_UI.DamageController damageController;
    [SerializeField]
    private RPG_UI.HealthBarController healthBarController;
    public int currentHealth;
    [SerializeField]
    public int attackPower = 20;
    void Start()
    {
        currentHealth = healthBarController.GetMaxHealth();
    }

    public void DoDamage(int damage)
    {
        damageController.DealDamage(damage);
        currentHealth = healthBarController.GetCurrentHealth();
    }

}
