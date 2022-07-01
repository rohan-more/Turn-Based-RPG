using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RPG_UI
{
    public class HeroSelector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public RPG.CharacterData.CharacterName character;
        [SerializeField]
        private Button selectHeroButton;
        [SerializeField]
        private TMPro.TMP_Text clicked;
        public bool isSelected;

        private bool isPointerDown;
        float pointerDownTimer;
        float holdTime = 1.3f;

        void OnEnable()
        {
            selectHeroButton.onClick.AddListener(SelectHero);
            EventManager.UpdateHeros.AddListener(UpdateSelection);
        }
        void OnDisable()
        {
            selectHeroButton.onClick.RemoveListener(SelectHero);
            EventManager.UpdateHeros.RemoveListener(UpdateSelection);
        }

        public void SelectHero()
        {
            selectHeroButton.image.color = Color.green;
            if (BattleManager.GetHeroCount() < BattleManager.HERO_COUNT)
            {
                BattleManager.AddToHeroQueue(character);
            }
            else
            {
                BattleManager.RemoveFromHeroQueue();
                BattleManager.AddToHeroQueue(character);
                EventManager.UpdateHeros.Invoke();
            }

        }

        public void UpdateSelection()
        {
            if (!BattleManager.HeroQueue.Contains(character))
            {
                selectHeroButton.image.color = Color.white;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isPointerDown = true;
            //Debug.Log(this.gameObject.name + " held down");
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPointerDown = false;
            //Debug.Log(this.gameObject.name + " left");
        }

        private void Update()
        {
            if(isPointerDown)
            {
                pointerDownTimer += Time.deltaTime;
                if (pointerDownTimer >= holdTime)
                {
                    isPointerDown = false;
                    pointerDownTimer = 0;
                    clicked.text = character + " held down";
                }
            }
        }
    }
}
