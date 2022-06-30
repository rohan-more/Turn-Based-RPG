using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG_UI
{
    public class BattleUIManager : MonoBehaviour
    {
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

        private void SelectHeroes()
        {
            BattleManager.PrintHeroQueue();
        }

    }
}


