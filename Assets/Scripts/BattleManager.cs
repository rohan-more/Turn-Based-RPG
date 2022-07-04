using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public static class BattleManager
    {
        public const float HERO_COUNT = 3;
        private static List<RPG.CharacterData.CharacterName> HeroList = new List<RPG.CharacterData.CharacterName>();

        #region Helper Functions

        public static List<RPG.CharacterData.CharacterName> GetHeroList()
        {
            return HeroList;
        }

        public static void AddToHeroList(RPG.CharacterData.CharacterName character)
        {
            if (!HeroList.Contains(character))
            {
                HeroList.Add(character);
            }
        }

        public static void RemoveFromHeroList(RPG.CharacterData.CharacterName character)
        {
            if (HeroList.Contains(character))
            {
                HeroList.Remove(character);
            }
        }

        public static int GetHeroCount()
        {
            return HeroList.Count;
        }

        public static bool IsHeroInList(RPG.CharacterData.CharacterName name)
        {
            return HeroList.Contains(name);
        }

        public static void PrintHeroList()
        {
            foreach (var item in HeroList)
            {
                Debug.Log(item);
            }
        }
        #endregion


    }
}

