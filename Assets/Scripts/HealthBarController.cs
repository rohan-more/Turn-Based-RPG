using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_UI
{
    public class HealthBarController : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;

        public void SetHealth(int health)
        {
            slider.value = health;
        }

        public void SetMaxHealth(int health)
        {
            slider.maxValue = health;
            slider.value = health;
        }

        public void Damage(int value)
        {
            slider.value -= value;
        }

    }
}

