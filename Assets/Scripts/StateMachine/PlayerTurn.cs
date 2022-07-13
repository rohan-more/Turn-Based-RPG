using System.Collections;
using UnityEngine;

namespace RPG.StateMachine
{
    public class PlayerTurn : State
    {
        public BattleState stateName = BattleState.PLAYER_TURN;
        public override IEnumerator Attack(BattleStateManager battleManager, int damage)
        {
            battleManager.boss.DoDamage(damage);
            if (battleManager.boss.currentHealth <= 0)
            {
                battleManager.ChangeStateTo(battleManager.PlayerWinState);
                battleManager.HasPlayerWon(true);
            }
            else
            {
                yield return new WaitForSeconds(1.5f);
                battleManager.ChangeStateTo(battleManager.BossTurnState);
                battleManager.AttackPlayer();
            }
        }
    }


}
