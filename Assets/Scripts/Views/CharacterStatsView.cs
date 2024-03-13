using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.UI
{
    public class CharacterStatsView : MonoBehaviour
    {
        [SerializeField] private RPG.CharacterData.CharacterName character;
        [SerializeField] private HeroSaveData heroData;

        [SerializeField] private TMPro.TMP_Text attackText;
        [SerializeField] private TMPro.TMP_Text levelText;
        [SerializeField] private TMPro.TMP_Text xpText;
        [SerializeField] private TMPro.TMP_Text healthText;

        public void PopulateData(RPG.CharacterData.CharacterName name)
        {
            character = name;
            if (!string.IsNullOrEmpty(character.ToString()))
            {
                SaveSystem.LoadSaveFile(character.ToString());
                GameDataManager.Instance.HeroSavedData.TryGetValue(character, out heroData);
            }

            attackText.text = "Attack: " + heroData.attackPower.ToString();
            levelText.text = "Level: " + heroData.level.ToString();
            xpText.text = "XP: " + heroData.xP.ToString();
            healthText.text = "Health: " + heroData.health.ToString();

        }

    }
}

