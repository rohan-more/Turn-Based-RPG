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
        public RPG.HeroList heroDataList;
        private List<HeroSelector> heroUIList = new List<HeroSelector>();
        public Transform heroesParent;
        public GameObject heroPrefab;

        private void Awake()
        {
            foreach (var item in heroDataList.All)
            {
                SaveSystem.CreateSaveFile(item);
            }
        }

        void Start()
        {
            CreateHeroToggles();

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
                        UnlockHero(item);
                        return;
                    }
                }
            }

        }

        private void CreateHeroToggles()
        {
            for (int i = 0; i < heroDataList.All.Count; i++)
            {
                GameObject heroTogglePrefab = Instantiate(heroPrefab, heroesParent);

                HeroSelector hero = heroTogglePrefab.GetComponent<HeroSelector>();
                hero.heroData = heroDataList.All[i];
                heroTogglePrefab.transform.name = hero.heroData.name;
                heroUIList.Add(hero);
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


