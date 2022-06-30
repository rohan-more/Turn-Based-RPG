using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_UI
{
    public class HeroSelector : MonoBehaviour
    {
        public RPG.CharacterData.CharacterName character;
        [SerializeField]
        private Button selectHeroButton;
        [SerializeField]
        private TMPro.TMP_Text clicked;

        void Start()
        {
            selectHeroButton.onClick.AddListener(SelectHero);
        }

        public void SelectHero()
        {
            if (BattleManager.GetHeroCount() < BattleManager.HERO_COUNT)
            {
                BattleManager.AddToHeroQueue(character);
            }
            else
            {
                BattleManager.RemoveFromHeroQueue();
                BattleManager.AddToHeroQueue(character);
            }
        }

    }
}
