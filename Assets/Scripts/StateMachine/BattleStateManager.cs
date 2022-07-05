using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.StateMachine;
public class BattleStateManager : MonoBehaviour
{
    State currentState;
    PlayerTurn PlayerTurnState = new PlayerTurn();
    BossTurn BossTurnState = new BossTurn();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
