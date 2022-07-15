using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.StateMachine
{
    public class PlayerWon : State
    {
        public override BattleState StateName => BattleState.WIN;

        public override IEnumerator Execute(BattleStateManager battleManager)
        {
            yield return new WaitForSeconds(1.0f);
        }
    }

}


