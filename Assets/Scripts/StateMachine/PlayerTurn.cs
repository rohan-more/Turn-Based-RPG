using System.Collections;
using UnityEngine;

namespace RPG.StateMachine
{
    public class PlayerTurn : State
    {
        public override BattleState StateName => BattleState.PLAYER_TURN;
        public override IEnumerator Execute(BattleStateManager battleManager)
        {
            battleManager.boss.DoDamage(battleManager.attackingHero.heroData.attackPower);
            if (battleManager.boss.currentHealth <= 0)
            {
                battleManager.SetState(battleManager.PlayerWinState);
                battleManager.HasPlayerWon(true);
            }
            else
            {
                yield return new WaitForSeconds(1.5f);
                battleManager.SetState(battleManager.BossTurnState);
                battleManager.AttackPlayer();
            }
        }
    }


}
