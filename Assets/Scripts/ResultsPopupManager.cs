using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace RPG_UI
{
    public class ResultsPopupManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject parent;
        [SerializeField]
        private Button lobbyButton;

        [SerializeField]
        private Image winImage;
        [SerializeField]
        private Image loseImage;
        [SerializeField]
        private TMPro.TMP_Text statusText;
        private const string LobbyScene = "Setup";

        private void OnEnable()
        {
            lobbyButton.onClick.AddListener(BackToLobby);
        }

        private void OnDisable()
        {
            lobbyButton.onClick.RemoveListener(BackToLobby);
        }
        void BackToLobby()
        {
            HeroUnlockManager.UpdateBattleCount();
            SceneManager.LoadScene(LobbyScene, LoadSceneMode.Single);
        }

        public IEnumerator BattleState(bool hasWon)
        {
            yield return new WaitForSeconds(1.5f);
            parent.SetActive(true);
            if (hasWon)
            {
                winImage.gameObject.SetActive(true);
                loseImage.gameObject.SetActive(false);
                statusText.text = "Congratulations, you won!";
            }
            else
            {
                loseImage.gameObject.SetActive(true);
                winImage.gameObject.SetActive(false);
                statusText.text = "You lost! Try again....";
            }
        }

    }
}

