using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.StateMachine
{
    public class PlayerLost : State
    {
        public override BattleState StateName => BattleState.LOSE;
        public override IEnumerator Execute(BattleStateManager battleManager)
        {
            yield return new WaitForSeconds(1.0f);
        }
    }

}


