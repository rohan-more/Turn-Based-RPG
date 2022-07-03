using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace RPG_UI
{
    public class BattleUIManager : MonoBehaviour
    {
        [SerializeField]
        private Button battleButton;
        private const string BattleScene = "Battle";
        void Start()
        {
            battleButton.onClick.AddListener(StartBattle);
        }

        private void OnEnable()
        {
            EventManager.EnableBattle.AddListener(ToggleBattleButton);
        }

        private void OnDisable()
        {
            EventManager.EnableBattle.RemoveListener(ToggleBattleButton);
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
            SceneManager.LoadScene(BattleScene, LoadSceneMode.Additive);
        }
    }
}


