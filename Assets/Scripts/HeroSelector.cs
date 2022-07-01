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
        public bool isSelected;
        void Start()
        {
            selectHeroButton.onClick.AddListener(SelectHero);
            EventManager.UpdateHeros.AddListener(UpdateSelection);
        }

        public void SelectHero()
        {
            selectHeroButton.image.color = Color.green;
            if (BattleManager.GetHeroCount() < BattleManager.HERO_COUNT)
            {
                BattleManager.AddToHeroQueue(character);
            }
            else
            {
                BattleManager.RemoveFromHeroQueue();
                BattleManager.AddToHeroQueue(character);
                EventManager.UpdateHeros.Invoke();
            }

        }

        public void UpdateSelection()
        {
            if (!BattleManager.HeroQueue.Contains(character))
            {
                selectHeroButton.image.color = Color.white;
            }
        }

    }
}
