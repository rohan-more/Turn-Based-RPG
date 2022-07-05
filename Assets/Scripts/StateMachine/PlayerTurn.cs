using System.Collections;
using UnityEngine;

namespace RPG.StateMachine
{
    public class PlayerTurn : State
    {
        public BattleState stateName = BattleState.PLAYER_TURN;
        public override IEnumerator Attack(BattleArenaManager battleManager, int damage)
        {
            if (battleManager.boss.currentHealth <= 0)
            {
                Debug.Log("You won!");
            }
            else
            {
                battleManager.boss.DoDamage(damage);
            }
            yield return new WaitForSeconds(1.5f);
            //Debug.Log("Boss Turn");
            battleManager.ChangeStateTo(battleManager.BossTurnState);
            battleManager.AttackPlayer();
        }
    }
}
