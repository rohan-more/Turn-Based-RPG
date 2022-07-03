using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_UI
{
    public class StatPopupManager : MonoBehaviour
    {
        public List<RPG.HeroData> heroList;
        public GameObject statPanel;
        [SerializeField]
        private Button closeButton;
        [SerializeField]
        private FillHeroStats heroStats;

        private void OnEnable()
        {
            EventManager.DisplayHeroStats.AddListener(LoadPopupData);
            EventManager.GetHeroImage.AddListener(LoadHeroImage);
            closeButton.onClick.AddListener(ClosePopup);
        }

        private void OnDisable()
        {
            EventManager.DisplayHeroStats.RemoveListener(LoadPopupData);
            EventManager.GetHeroImage.RemoveListener(LoadHeroImage);
            closeButton.onClick.RemoveListener(ClosePopup);
        }

        private void ClosePopup()
        {
            statPanel.SetActive(false);
        }

        void LoadPopupData(HeroSaveData heroData)
        {
            heroStats.UpdateSavedStats(heroData);
        }


        void LoadHeroImage(RPG.CharacterData.CharacterName characterName)
        {
            statPanel.SetActive(true);
            foreach (var item in heroList)
            {
                if (item.heroName == characterName)
                {
                    heroStats.UpdateImage(item);
                    return;
                }
            }
        }

    }
}
