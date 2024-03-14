
using UnityEngine;
using UnityEngine.UI;
namespace RPG.UI
{
    public class CharacterSelectionView : MonoBehaviour
    {
        public RPG.HeroData heroData;
        [SerializeField]
        private Toggle heroToggle;
        [SerializeField]
        private CharacterStatsView statsView;
        [SerializeField]
        private TMPro.TMP_Text lockedText;
        [SerializeField] private Image profileImage;
        [SerializeField] private Image lockedIcon;
        [SerializeField] private Image selectedIcon;
        public RPG.CharacterData.LockedState LOCKEDSTATE;

        private void Start()
        {
            if (heroData != null)
            {
                heroToggle.image.sprite = heroData.heroSprite;
                lockedText.text = heroData.heroName.ToString();
                statsView.PopulateData(heroData.heroName);
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
        
        public void SetCharacterData(HeroData data)
        {
            heroData = data;
            profileImage.sprite = data.heroSprite;
            lockedText.text = data.heroName.ToString();

            selectedIcon.gameObject.SetActive(heroData.isSelected != CharacterData.SelectedState.UNSELECTED);
            
            if (heroData.isLocked == CharacterData.LockedState.LOCKED)
            {
                LockHero();
            }
            else
            {
                UnlockHero();
            }
        }

        private void LockHero()
        {
            LOCKEDSTATE = RPG.CharacterData.LockedState.LOCKED;
            heroToggle.interactable = false;
            lockedIcon.gameObject.SetActive(true);
        }

        private void UnlockHero()
        {
            LOCKEDSTATE = RPG.CharacterData.LockedState.UNLOCKED;
            heroToggle.interactable = true;
            lockedIcon.gameObject.SetActive(false);
        }

        public void ToggleSelect(bool value)
        {
            selectedIcon.gameObject.SetActive(value);

            heroData.isSelected = value ? CharacterData.SelectedState.SELECTED : CharacterData.SelectedState.UNSELECTED;

            AddToParty(value);
        }


        private void AddToParty(bool isSelected)
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

        private void ToggleHero(bool isSelected)
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
        }
    }
}

