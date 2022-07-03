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
        private LoadHeroStats heroStats;
        [SerializeField]
        private HeroImageButton heroButton;
        [SerializeField]
        private TMPro.TMP_Text lockedText;
        [SerializeField]
        private Image lockedIcon;

private const string LOCKED = "LOCKED";
        private void Start()
        {
            heroToggle.image.sprite = heroData.heroSprite;
            lockedText.text = heroData.heroName.ToString();
            heroStats.heroData = heroData;
            heroButton.character = heroData.heroName;
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
                lockedIcon.gameObject.SetActive(true);
            }
        }
        void UnlockHero()
        {
            if (heroData.isLocked == RPG.CharacterData.LockedState.UNLOCKED)
            {
                heroToggle.interactable = true;
                lockedIcon.gameObject.SetActive(false);
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
