using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.StateMachine
{
    public class PlayerLost : State
    {
        public BattleState stateName = BattleState.LOSE;

        public override IEnumerator Lose(BattleArenaManager battleManager)
        {
            Debug.Log("PLAYER LOST");
            yield return new WaitForSeconds(1.0f);

        }
    }

}


