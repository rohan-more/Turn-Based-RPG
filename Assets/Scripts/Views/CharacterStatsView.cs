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

        private const string ATTACK = "Attack: ";
        private const string LEVEL = "Level: ";
        private const string XP = "XP: ";
        private const string HEALTH = "Health: ";
        private const string HIDDEN = "??";
        public void PopulateData(RPG.CharacterData.CharacterName name)
        {
            character = name;
            if (!string.IsNullOrEmpty(character.ToString()))
            {
                SaveSystem.LoadSaveFile(character.ToString());
                GameDataManager.Instance.HeroSavedData.TryGetValue(character, out heroData);
            }

            if (heroData.isUnlocked == CharacterData.LockedState.LOCKED.ToString())
            {
                attackText.text = ATTACK + HIDDEN;
                levelText.text = LEVEL + HIDDEN;
                xpText.text = XP + HIDDEN;
                healthText.text = HEALTH + HIDDEN;
                return;
            }
            attackText.text = ATTACK + heroData.attackPower;
            levelText.text = LEVEL + heroData.level;
            xpText.text = XP + heroData.xP;
            healthText.text = HEALTH + heroData.health;

        }

    }
}

