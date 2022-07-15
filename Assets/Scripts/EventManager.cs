using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent EnableHeroToggles = new UnityEvent();
    public static UnityEvent<bool> EnableBattle = new UnityEvent<bool>();
    public static UnityEvent<bool> IsPointerHeldDown = new UnityEvent<bool>();
    public static UnityEvent<HeroSaveData> DisplayHeroStats = new UnityEvent<HeroSaveData>();
    public static UnityEvent<bool> PlayerWon = new UnityEvent<bool>();
    public static UnityEvent HeroDead = new UnityEvent();
}
