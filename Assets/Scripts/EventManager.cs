using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent UpdateHeros = new UnityEvent();
    public static UnityEvent<bool> EnableBattle = new UnityEvent<bool>();
    public static UnityEvent<RPG.CharacterData.CharacterName> DisplayHeroStats = new UnityEvent<RPG.CharacterData.CharacterName>();

}
