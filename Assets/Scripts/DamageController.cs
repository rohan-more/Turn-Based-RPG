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
        private Color healthColor = Color.black;
        private Color normalColor;
        private readonly float BLINK_SPEED = 2;
        private float attackDuration;
        private const float MAX_BLINK_TIME = 1.0f;
        private bool isAttacked;

        private void Start()
        {
            normalColor = barImage.color;
        }
        public void DealDamage(int damage)
        {
            healthBarController.Damage(damage);
            isAttacked = true;
        }

        void Update()
        {
            if (isAttacked)
            {
                attackDuration += Time.deltaTime;
                barImage.color = Color.Lerp(healthColor, damageColor, Mathf.PingPong(Time.time * BLINK_SPEED, 1));

                if (attackDuration >= MAX_BLINK_TIME)
                {
                    barImage.color = normalColor;
                    isAttacked = false;
                    attackDuration = 0;
                }
            }
        }
    }
}

