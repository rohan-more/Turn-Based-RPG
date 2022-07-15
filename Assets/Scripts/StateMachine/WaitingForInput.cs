using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.StateMachine
{
    public class WaitingForInput : State
    {
        public override BattleState StateName => BattleState.WAITING_INPUT;
        public override IEnumerator Enter()
        {
            yield return new WaitForSeconds(1.5f);
        }
    }
}
