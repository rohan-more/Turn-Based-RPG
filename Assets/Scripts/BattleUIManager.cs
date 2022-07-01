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

        public void StartBattle()
        {
            clicked.text = "Start Battle!";
            SelectHeroes();
        }

        private void UpdateHeroQueue()
        {
            foreach (var item in heroList)
            {
                if(!BattleManager.HeroQueue.Contains(item.character))
                {
                    item.UpdateSelection();
                }
            }
        }

        private void SelectHeroes()
        {
            BattleManager.PrintHeroQueue();
        }

    }
}


