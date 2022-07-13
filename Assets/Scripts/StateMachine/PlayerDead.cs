using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.StateMachine
{
    public class PlayerDead : State
    {
        public BattleState stateName = BattleState.HERO_DEAD;

        public override IEnumerator Death(BattleStateManager battleManager)
        {
            battleManager.attackedHero.DisableHero();
            yield return new WaitForSeconds(1.5f);

        }
    }

}


