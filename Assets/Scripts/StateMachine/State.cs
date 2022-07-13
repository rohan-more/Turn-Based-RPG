using System.Collections;
namespace RPG.StateMachine
{
    public abstract class State
    {
        public enum BattleState { WAITING_INPUT, PLAYER_TURN, BOSS_TURN, HERO_DEAD, WIN, LOSE }
        private BattleState stateName;
        public virtual BattleState StateName { get => stateName; set => stateName = value; }

        public virtual IEnumerator Start()
        {
            yield break;
        }
        public virtual IEnumerator Attack(BattleStateManager battleManager, int damage)
        {
            yield break;
        }
        public virtual IEnumerator Death(BattleStateManager battleManager)
        {
            yield break;
        }
        public virtual IEnumerator Win(BattleStateManager battleManager)
        {
            yield break;
        }
        public virtual IEnumerator Lose(BattleStateManager battleManager)
        {
            yield break;
        }
    }

}
