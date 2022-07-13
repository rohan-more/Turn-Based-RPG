using System.Collections;
using UnityEngine;

namespace RPG.StateMachine
{
    public class BossTurn : State
    {
        public BattleState stateName = BattleState.BOSS_TURN;
        public override IEnumerator Attack(BattleStateManager battleManager, int damage)
        {
            battleManager.attackedHero.DoDamage(damage);
            if (battleManager.attackedHero.currentHealth <= 0)
            {
                battleManager.ChangeStateTo(battleManager.PlayerDeadState);
                battleManager.HeroDeath();
            }
            yield return new WaitForSeconds(1.5f);
            battleManager.AwaitingPlayerInput();

        }
    }
}



