using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace RPG_UI
{
    public class BattleUIManager : MonoBehaviour
    {
        [SerializeField]
        private List<HeroSelector> heroList;
        [SerializeField]
        private Button battleButton;
        [SerializeField]
        private TMPro.TMP_Text clicked;
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
            clicked.text = "Start Battle!";
            SelectHeroes();
        }

        private void SelectHeroes()
        {
            RPG.BattleManager.PrintHeroList();
        }

    }
}


