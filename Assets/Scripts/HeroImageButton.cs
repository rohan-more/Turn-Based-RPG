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
    public HeroSaveData heroData;

    public void GetHeroData(RPG.CharacterData.CharacterName name)
    {
        character = name;
        if (!string.IsNullOrEmpty(character.ToString()))
        {
            SaveSystem.LoadSaveFile(character.ToString());
            GameDataManager.Instance.HeroSavedData.TryGetValue(character, out heroData);
        }
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
                EventManager.IsPointerHeldDown.Invoke(!isPointerDown);
                if(heroData != null)
                {
                    EventManager.DisplayHeroStats.Invoke(heroData);
                }
            }
        }
    }
}
