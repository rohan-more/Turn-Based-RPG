using System.Collections;
using UnityEngine;

namespace RPG.StateMachine
{
    public class BossTurn : State
    {
        public BattleState stateName = BattleState.BOSS_TURN;
        public override IEnumerator Attack(BattleArenaManager battleManager, int damage)
        {
            if(battleManager.selectedHero.currentHealth <= 0)
            {
                Debug.Log("You lost!");
            }
            else
            {
                battleManager.selectedHero.DoDamage(damage);
            }

            yield return new WaitForSeconds(1.5f);
            //Debug.Log("Player Turn");
        }
    }
}



