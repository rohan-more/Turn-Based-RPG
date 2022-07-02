using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RPG_UI
{
    public class HeroSelector : MonoBehaviour
    {
        [SerializeField]
        private RPG.HeroData heroData;
        [SerializeField]
        private Toggle heroToggle;
        [SerializeField]
        private TMPro.TMP_Text lockedText;
        [SerializeField]
        private TMPro.TMP_Text clicked;

        private const string LOCKED = "LOCKED";
        private void Start()
        {
            heroToggle.image.sprite = heroData.heroSprite;
            LockHero();
        }

        void OnEnable()
        {
            heroToggle.onValueChanged.AddListener(ToggleHero);
        }
        void OnDisable()
        {
            heroToggle.onValueChanged.RemoveListener(ToggleHero);
        }

        void LockHero()
        {
            if (heroData.isLocked == RPG.CharacterData.LockedState.LOCKED)
            {
                heroToggle.interactable = false;
                lockedText.text = LOCKED;
            }
        }
        void UnlockHero()
        {
            if (heroData.isLocked == RPG.CharacterData.LockedState.UNLOCKED)
            {
                heroToggle.interactable = true;
                lockedText.text = string.Empty;
            }
        }
        public void ToggleHero(bool isSelected)
        {
            if (isSelected)
            {
                if (RPG.BattleManager.GetHeroCount() < RPG.BattleManager.HERO_COUNT)
                {
                    RPG.BattleManager.AddToHeroList(heroData.heroName);
                    heroToggle.image.color = Color.green;
                }
            }
            else
            {
                RPG.BattleManager.RemoveFromHeroList(heroData.heroName);
                heroToggle.image.color = Color.white;

            }

            if (RPG.BattleManager.GetHeroCount() == RPG.BattleManager.HERO_COUNT)
            {
                EventManager.EnableBattle?.Invoke(true);
            }
            else if (RPG.BattleManager.GetHeroCount() < RPG.BattleManager.HERO_COUNT)
            {
                EventManager.EnableBattle?.Invoke(false);
            }
        }
    }
}
