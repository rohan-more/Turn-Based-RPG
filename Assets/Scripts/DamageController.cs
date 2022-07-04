using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_UI
{
    public class DamageController : MonoBehaviour
    {
        [SerializeField]
        private HealthBarController healthBarController;
        [SerializeField]
        private Image barImage;

        private Color damageColor = Color.red;
        private Color healthColor = Color.green;
        private readonly float BLINK_SPEED = 2;

        private void DealDamage(int damage)
        {
            healthBarController.Damage(damage);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DealDamage(10);
            }
            //barImage.color = Color.Lerp(healthColor, damageColor, Mathf.PingPong(Time.time * BLINK_SPEED, 1));
        }
    }
}

