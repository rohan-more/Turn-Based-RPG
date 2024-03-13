
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
        [SerializeField] private Button unselectBtn;

        [SerializeField] private LobbyUIManager lobbyManager;
        [SerializeField] private CharacterStatsView statsView;
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
            selectBtn.onClick.AddListener(SelectCharacter);
            unselectBtn.onClick.AddListener(UnselectCharacter);
        }

        private void OnDisable()
        {
            leftBtn.onClick.RemoveListener(ShiftLeft);
            rightBtn.onClick.RemoveListener(ShiftRight);
            selectBtn.onClick.RemoveListener(SelectCharacter);
            unselectBtn.onClick.RemoveListener(UnselectCharacter);
        }

        private void SelectCharacter()
        {
            centerCharacter.ToggleSelect(true);
        }

        private void UnselectCharacter()
        {
            centerCharacter.ToggleSelect(false);
        }

        private void ShiftLeft()
        {
            if (leftIndex == -1)
            {
                Debug.Log("Reached Left end");
                return;
            }
            leftIndex--;
            centerIndex--;
            rightIndex--;

            UpdateCarousel();
        }

        private void GetCharacterData(int index, CharacterSelectionView character)
        {
            if (index == -1 || index == lobbyManager.GetListCount())
            {
                return;
            }
            
            HeroData data = lobbyManager.GetHeroDataByIndex(index);
            character.SetCharacterData(data);
        }

        private void UpdateCarousel()
        {
            GetCharacterData(leftIndex, leftCharacter);
            GetCharacterData(centerIndex, centerCharacter);
            GetCharacterData(rightIndex, rightCharacter);
            statsView.PopulateData(centerCharacter.heroData.heroName);

            leftCharacter.gameObject.SetActive(leftIndex != -1);

            rightCharacter.gameObject.SetActive(rightIndex != lobbyManager.GetListCount());

            if(centerCharacter.heroData.isSelected == CharacterData.SelectedState.SELECTED) 
            {
                selectBtn.gameObject.SetActive(false);
                unselectBtn.gameObject.SetActive(true);
            }
            else
            {
                selectBtn.gameObject.SetActive(true);
                unselectBtn.gameObject.SetActive(false);
            }
        }

        private void ShiftRight()
        {
            if (rightIndex == lobbyManager.GetListCount())
            {
                Debug.Log("Reached Right end");
                return;
            }
            leftIndex++;
            centerIndex++;
            rightIndex++;

            UpdateCarousel();
        }

    }
}

