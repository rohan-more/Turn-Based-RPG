using System.Collections;
namespace RPG.StateMachine
{
    public abstract class State
    {
        public enum BattleState { PLAYER_TURN, BOSS_TURN, WIN, LOSE }
        private BattleState stateName;
        public virtual BattleState StateName { get => stateName; set => stateName = value; }

        public virtual IEnumerator Start()
        {
            yield break;
        }
        public virtual IEnumerator Attack(BattleArenaManager battleManager, int damage)
        {
            yield break;
        }
    }

}
