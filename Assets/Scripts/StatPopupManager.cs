using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_UI
{
    public class StatPopupManager : MonoBehaviour
    {
        [SerializeField]
        private RPG.HeroList heroDataList;
        public GameObject statPanel;
        [SerializeField]
        private Button closeButton;
        [SerializeField]
        private FillHeroStats heroStats;

        private void OnEnable()
        {
            EventManager.DisplayHeroStats.AddListener(LoadPopupData);
            closeButton.onClick.AddListener(ClosePopup);
        }

        private void OnDisable()
        {
            EventManager.DisplayHeroStats.RemoveListener(LoadPopupData);
            closeButton.onClick.RemoveListener(ClosePopup);
        }

        private void ClosePopup()
        {
            statPanel.SetActive(false);
        }

        void LoadPopupData(HeroSaveData heroData)
        {
            heroStats.UpdateSavedStats(heroData);
            LoadHeroImage(heroData.heroName);
        }

        void LoadHeroImage(string characterName)
        {
            statPanel.SetActive(true);
            foreach (var item in heroDataList.All)
            {
                if (item.heroName.ToString() == characterName)
                {
                    heroStats.UpdateImage(item);
                    return;
                }
            }
        }
    }
}
