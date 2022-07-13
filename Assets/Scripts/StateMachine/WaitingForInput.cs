using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.StateMachine
{
    public class WaitingForInput : State
    {
        public BattleState stateName = BattleState.WAITING_INPUT;
        public override IEnumerator Start()
        {
            yield return new WaitForSeconds(1.5f);
        }
    }
}
