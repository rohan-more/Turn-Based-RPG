using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG_UI
{
    public class DamageController : MonoBehaviour
    {
        [SerializeField]
        private HealthBarController healthBarController;

        private void DealDamage(int damage)
        {
            healthBarController.Damage(damage);
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                DealDamage(10);
            }
        }
    }
}

