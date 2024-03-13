
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

            if(heroData.isSelected == CharacterData.SelectedState.UNSELECTED ) 
            {
                selectedIcon.gameObject.SetActive(false);
            }
            else
            {
                selectedIcon.gameObject.SetActive(true);
            }

            //heroData.isSelected = CharacterData.SelectedState.SELECTED;
            if (heroData.isLocked == CharacterData.LockedState.LOCKED)
            {
                LockHero();
            }
            else
            {
                UnlockHero();
            }
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

        public void ToggleSelect(bool value)
        {
            selectedIcon.gameObject.SetActive(value);
            if(value) 
            {
                heroData.isSelected = CharacterData.SelectedState.SELECTED;
            }
            else
            {
                heroData.isSelected = CharacterData.SelectedState.UNSELECTED;
            }

            AddToParty(value);
        }


        public void AddToParty(bool isSelected)
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

