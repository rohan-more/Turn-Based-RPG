using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/HeroList", order = 1)]
    public class HeroList : ScriptableObject
    {
        [SerializeField]
        private List<HeroData> all;

        public List<HeroData> All { get => all; set => all = value; }
    }
}

