using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.StateMachine
{
    public class PlayerWon : State
    {
        public BattleState stateName = BattleState.WIN;

        public override IEnumerator Win(BattleArenaManager battleManager)
        {
            yield return new WaitForSeconds(1.0f);
        }
    }

}


