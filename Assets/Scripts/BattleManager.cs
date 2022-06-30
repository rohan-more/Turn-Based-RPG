using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BattleManager
{
    public const float HERO_COUNT = 3;
    private static Queue<RPG.CharacterData.CharacterName> HeroQueue = new Queue<RPG.CharacterData.CharacterName>();

    public static void AddToHeroQueue(RPG.CharacterData.CharacterName character)
    {
        if (HeroQueue.Count < HERO_COUNT && !HeroQueue.Contains(character))
        {
            HeroQueue.Enqueue(character);
        }
        else
        {
            HeroQueue.Dequeue();
            HeroQueue.Enqueue(character);
        }
    }

    public static void RemoveFromHeroQueue()
    {
        HeroQueue.Dequeue();
    }

    public static int GetHeroCount()
    {
        return HeroQueue.Count;
    }

    public static void PrintHeroQueue()
    {
        foreach (var item in HeroQueue)
        {
            Debug.Log(item);
        }
    }


}
