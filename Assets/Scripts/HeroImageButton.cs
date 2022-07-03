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
                EventManager.DisplayHeroStats.Invoke(character);
            }
        }
    }
}
