using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace RPG_UI
{
    public class LobbyUIManager : MonoBehaviour
    {
        [SerializeField]
        private Button battleButton;
        [SerializeField]
        private Button exitButton;
        private const string BattleScene = "Battle";
        public List<RPG.HeroData> heroDataList;
        public List<HeroSelector> heroUIList;

        private void Awake()
        {
            foreach (var item in heroDataList)
            {
                SaveSystem.CreateSaveFile(item);
            }
        }

        void Start()
        {
            foreach (var item in heroUIList)
            {
                HeroUnlockManager.CheckHeroStatus(item);
            }

            if (HeroUnlockManager.GetBattleCount() % HeroUnlockManager.UNLOCK_HERO_COUNT == 0)
            {
                foreach (var item in heroUIList)
                {
                    if (item.LOCKEDSTATE == RPG.CharacterData.LockedState.LOCKED)
                    {
                        Debug.Log("Unlocking " + item.heroData.name);
                        UnlockHero(item);
                        return;
                    }
                }
            }

        }

        private void ExitApplication()
        {
            Application.Quit();
        }

        private void OnEnable()
        {
            EventManager.EnableBattle.AddListener(ToggleBattleButton);
            exitButton.onClick.AddListener(ExitApplication);
            battleButton.onClick.AddListener(StartBattle);
        }

        private void OnDisable()
        {
            EventManager.EnableBattle.RemoveListener(ToggleBattleButton);
            exitButton.onClick.RemoveListener(ExitApplication);
            battleButton.onClick.RemoveListener(StartBattle);
        }

        public static void UnlockHero(RPG_UI.HeroSelector item)
        {
            SaveSystem.LoadHeroSaveFile(item.heroData);
            item.UnlockHero();
        }

        void ToggleBattleButton(bool enable)
        {
            if (enable && RPG.BattleManager.GetHeroCount() == RPG.BattleManager.HERO_COUNT)
            {
                battleButton.gameObject.SetActive(true);
            }
            else
            {
                battleButton.gameObject.SetActive(false);
            }
        }

        public void StartBattle()
        {
            this.gameObject.SetActive(false);
            GameDataManager.Instance.SelectedHeroes = RPG.BattleManager.GetHeroList();
            SceneManager.LoadScene(BattleScene, LoadSceneMode.Single);
        }
    }
}


