using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/HeroData", order = 1)]
    public class HeroData : ScriptableObject
    {
        public CharacterData.CharacterName heroName;
        public CharacterData.LockedState isLocked;
        public CharacterData.SelectedState isSelected;
        public float maxHealth;
        public float attackPower;
        public int level;
        public Sprite heroSprite;
    }
}

