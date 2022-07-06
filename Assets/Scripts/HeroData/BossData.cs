using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BossData", order = 1)]
    public class BossData : ScriptableObject
    {
        public CharacterData.Boss bossName;
        public int maxHealth;
        public int attackPower;
    }
}
