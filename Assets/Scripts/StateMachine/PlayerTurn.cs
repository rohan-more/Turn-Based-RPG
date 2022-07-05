using System.Collections;
using UnityEngine;

namespace RPG.StateMachine
{
    public class PlayerTurn : State
    {
        public BattleState stateName = BattleState.PLAYER_TURN;
        public override IEnumerator Attack(BattleArenaManager battleManager, int damage)
        {
            Debug.Log(battleManager.attackingHero.heroData.name + " is attacking " + battleManager.selectedBoss.bossData.name);
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

    public class PlayerDead : State
    {
        public BattleState stateName = BattleState.HERO_DEAD;

        public override IEnumerator Death(BattleArenaManager battleManager)
        {
            battleManager.attackedHero.DisableHero();
            yield return new WaitForSeconds(1.5f);

        }
    }

    public class PlayerWon : State
    {
        public BattleState stateName = BattleState.WIN;

        public override IEnumerator Win(BattleArenaManager battleManager)
        {
            Debug.Log("PLAYER WIN");
            yield return new WaitForSeconds(1.0f);

        }
    }

    public class PlayerLost : State
    {
        public BattleState stateName = BattleState.LOSE;

        public override IEnumerator Lose(BattleArenaManager battleManager)
        {
            Debug.Log("PLAYER LOST");
            yield return new WaitForSeconds(1.0f);

        }
    }



}
