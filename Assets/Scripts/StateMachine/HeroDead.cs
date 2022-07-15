using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.StateMachine
{
    public class HeroDead : State
    {
        public override BattleState StateName => BattleState.HERO_DEAD;

        public override IEnumerator Execute(BattleStateManager battleManager)
        {
            battleManager.attackedHero.DisableHero();
            yield return new WaitForSeconds(1.5f);

        }
    }

}


