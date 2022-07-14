using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BossList", order = 1)]
    public class BossList : ScriptableObject
    {
        [SerializeField]
        private List<BossData> all;

        public List<BossData> All { get => all; set => all = value; }
    }

}
