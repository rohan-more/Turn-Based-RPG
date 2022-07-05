using System.Collections;
using UnityEngine;

namespace RPG.StateMachine
{
    public class BossTurn : State
    {
        public BattleState stateName = BattleState.BOSS_TURN;
        public override IEnumerator Attack(BattleArenaManager battleManager, int damage)
        {
            //Debug.Log(battleManager.selectedBoss.bossData.name + " is attacking " + battleManager.attackedHero.heroData.name);
            battleManager.attackedHero.DoDamage(damage);
            if (battleManager.attackedHero.currentHealth <= 0)
            {
                Debug.Log(battleManager.attackedHero.heroData.name + " is dead!");
                battleManager.ChangeStateTo(battleManager.PlayerDeadState);
                battleManager.HeroDeath();
            }
            battleManager.ActivateHeroes();
            yield return new WaitForSeconds(1.5f);

        }
    }
}



