using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RPG_UI
{
    public class HeroSelector : MonoBehaviour
    {
        public RPG.CharacterData.CharacterName character;
        [SerializeField]
        private Button selectHeroButton;
        [SerializeField]
        private TMPro.TMP_Text clicked;

        void OnEnable()
        {
            selectHeroButton.onClick.AddListener(SelectHero);
            EventManager.UpdateHeros.AddListener(UpdateQueue);
        }
        void OnDisable()
        {
            selectHeroButton.onClick.RemoveListener(SelectHero);
            EventManager.UpdateHeros.RemoveListener(UpdateQueue);
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

        public void UpdateQueue()
        {
            if (!BattleManager.HeroQueue.Contains(character))
            {
                selectHeroButton.image.color = Color.white;
            }
        }
    }
}
