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
        private const string BattleScene = "Battle";
        public List<RPG.HeroData> heroDataList;
        public List<HeroSelector> heroUIList;

        void Start()
        {
            foreach (var item in heroUIList)
            {
                HeroUnlockManager.CheckHeroStatus(item);
            }

            HeroUnlockManager.GetBattleCount();
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

        private void OnEnable()
        {
            EventManager.EnableBattle.AddListener(ToggleBattleButton);
            battleButton.onClick.AddListener(StartBattle);
        }

        private void OnDisable()
        {
            EventManager.EnableBattle.RemoveListener(ToggleBattleButton);
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


