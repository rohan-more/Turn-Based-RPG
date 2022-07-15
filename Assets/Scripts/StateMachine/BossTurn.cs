using System.Collections;
using UnityEngine;

namespace RPG.StateMachine
{
    public class BossTurn : State
    {
        public override BattleState StateName => BattleState.BOSS_TURN;

        public override IEnumerator Execute(BattleStateManager battleManager)
        {
            battleManager.attackedHero.DoDamage(battleManager.boss.bossData.attackPower);
            if (battleManager.attackedHero.currentHealth <= 0)
            {
                battleManager.SetState(battleManager.PlayerDeadState);
                battleManager.HeroDeath();
            }
            yield return new WaitForSeconds(1.5f);
            battleManager.AwaitingPlayerInput();

        }
    }
}



