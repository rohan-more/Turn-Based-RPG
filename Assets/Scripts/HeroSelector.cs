using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RPG_UI
{
    public class HeroSelector : MonoBehaviour
    {
        public RPG.HeroData heroData;
        [SerializeField]
        private Toggle heroToggle;
        [SerializeField]
        private HeroImageButton heroButton;
        [SerializeField]
        private TMPro.TMP_Text lockedText;
        [SerializeField]
        private Image lockedIcon;
        public RPG.CharacterData.LockedState LOCKEDSTATE;

        private void Awake()
        {
            heroToggle.interactable = false;
            lockedIcon.gameObject.SetActive(true);
        }
        private void Start()
        {
            if(heroData != null)
            {
                heroToggle.image.sprite = heroData.heroSprite;
                lockedText.text = heroData.heroName.ToString();
                heroButton.GetHeroData(heroData.heroName);
            }

        }

        void OnEnable()
        {
            heroToggle.onValueChanged.AddListener(ToggleHero);
        }
        void OnDisable()
        {
            heroToggle.onValueChanged.RemoveListener(ToggleHero);
        }

        public void LockHero()
        {
            LOCKEDSTATE = RPG.CharacterData.LockedState.LOCKED;
            heroToggle.interactable = false;
            lockedIcon.gameObject.SetActive(true);
        }
        public void UnlockHero()
        {
            LOCKEDSTATE = RPG.CharacterData.LockedState.UNLOCKED;
            heroToggle.interactable = true;
            lockedIcon.gameObject.SetActive(false);
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
