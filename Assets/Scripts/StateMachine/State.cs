using System.Collections;
namespace RPG.StateMachine
{
    public abstract class State
    {
        public enum BattleState { PLAYER_TURN, BOSS_TURN, HERO_DEAD, WIN, LOSE }
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
        public virtual IEnumerator Death(BattleArenaManager battleManager)
        {
            yield break;
        }
        public virtual IEnumerator Win(BattleArenaManager battleManager)
        {
            yield break;
        }
        public virtual IEnumerator Lose(BattleArenaManager battleManager)
        {
            yield break;
        }
    }

}
