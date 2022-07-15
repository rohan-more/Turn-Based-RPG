using System.Collections;
namespace RPG.StateMachine
{
    public abstract class State
    {
        public enum BattleState { WAITING_INPUT, PLAYER_TURN, BOSS_TURN, HERO_DEAD, WIN, LOSE }
        public abstract BattleState StateName { get; }

        public virtual IEnumerator Enter()
        {
            yield break;
        }
        public virtual IEnumerator Execute(BattleStateManager battleManager)
        {
            yield break;
        }

        /*        public virtual IEnumerator Start()
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
                }*/
    }

}
