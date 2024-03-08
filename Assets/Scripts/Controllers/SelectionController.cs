using RPG.Models;
using RPG.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Controllers
{
    public class SelectionController : MonoBehaviour
    {
        [SerializeField] private CharacterSelectionView leftCharacter;
        [SerializeField] private CharacterSelectionView centerCharacter;
        [SerializeField] private CharacterSelectionView rightCharacter;

        [SerializeField] private Button leftBtn;
        [SerializeField] private Button rightBtn;
        [SerializeField] private Button selectBtn;

        [SerializeField] private LobbyUIManager lobbyManager;

        [SerializeField] private int leftIndex;
        [SerializeField] private int centerIndex;
        [SerializeField] private int rightIndex;
        void Start()
        {
             leftIndex = 0;
             centerIndex = 1;
             rightIndex = 2;
            UpdateCarousel();
        }

        private void OnEnable()
        {
            leftBtn.onClick.AddListener(ShiftLeft);
            rightBtn.onClick.AddListener(ShiftRight);
        }

        private void OnDisable()
        {
            leftBtn.onClick.RemoveListener(ShiftLeft);
            rightBtn.onClick.RemoveListener(ShiftRight);
        }

        private void ShiftLeft()
        {

            if (leftIndex == 0)
            {
                Debug.Log("Reached Left end");
                return;
            }
            else
            {
                leftIndex--;
                centerIndex--;
                rightIndex--;
            }

            UpdateCarousel();
        }

        private void GetCharacterData(int index, CharacterSelectionView character)
        {
            HeroData data = lobbyManager.GetHeroDataByIndex(index);
            character.SetCharacterData(data);
        }

        private void UpdateCarousel()
        {
            GetCharacterData(leftIndex, leftCharacter);
            GetCharacterData(centerIndex, centerCharacter);
            GetCharacterData(rightIndex, rightCharacter);
        }

        private void ShiftRight()
        {
            if (rightIndex == lobbyManager.heroDataList.All.Count - 1)
            {
                Debug.Log("Reached Right end");
                return;
            }
            else
            {
                leftIndex++;
                centerIndex++;
                rightIndex++;
            }

            UpdateCarousel();
        }

    }
}

