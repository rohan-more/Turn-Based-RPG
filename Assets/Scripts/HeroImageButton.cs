using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeroImageButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RPG.CharacterData.CharacterName character;
    private bool isPointerDown;
    private float pointerDownTimer;
    private const float HOLD_TIME = 1.3f;
    HeroSaveData heroData;

    private void Awake()
    {
        SaveSystem.LoadSaveFile(character.ToString());
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
    }
    private void FixedUpdate()
    {
        if (isPointerDown)
        {
            pointerDownTimer += Time.fixedDeltaTime;
            if (pointerDownTimer >= HOLD_TIME)
            {
                isPointerDown = false;
                pointerDownTimer = 0;
                GameDataManager.Instance.heroDict.TryGetValue(character, out heroData);
                EventManager.IsPointerHeldDown.Invoke(!isPointerDown);
                EventManager.DisplayHeroStats.Invoke(heroData);
            }
        }
    }
}
