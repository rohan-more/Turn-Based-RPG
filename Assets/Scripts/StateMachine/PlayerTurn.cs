using System.Collections;
using UnityEngine;

namespace RPG.StateMachine
{
    public class PlayerTurn : State
    {
        public BattleState stateName = BattleState.PLAYER_TURN;
        public override IEnumerator Attack(BattleArenaManager battleManager, int damage)
        {
           // Debug.Log(battleManager.attackingHero.heroData.name + " is attacking " + battleManager.selectedBoss.bossData.name);
            battleManager.selectedBoss.DoDamage(damage);
            if (battleManager.selectedBoss.currentHealth <= 0)
            {
                battleManager.ChangeStateTo(battleManager.PlayerWinState);
                battleManager.HasPlayerWon(true);
            }
            else
            {
                yield return new WaitForSeconds(1.5f);
                //Debug.Log("Boss Turn");
                battleManager.ChangeStateTo(battleManager.BossTurnState);
                battleManager.AttackPlayer();
            }
        }
    }


}
