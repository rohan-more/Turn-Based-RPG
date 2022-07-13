using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.StateMachine;

namespace RPG.StateMachine
{
    public class BattleStateManager : StateMachine
    {
        #region State Functions
        State currentState;
        public WaitingForInput WaitingForPlayerInput = new WaitingForInput();
        public PlayerTurn PlayerTurnState = new PlayerTurn();
        public BossTurn BossTurnState = new BossTurn();
        public PlayerDead PlayerDeadState = new PlayerDead();
        public PlayerWon PlayerWinState = new PlayerWon();
        public PlayerLost PlayerLoseState = new PlayerLost();

        public State CurrentState { get => currentState; set => currentState = value; }
        #endregion

        [HideInInspector]
        public HeroController attackedHero;
        [HideInInspector]
        public HeroController attackingHero;
        [HideInInspector]
        public BossController boss;

        #region StateMachine Functions
        /// <summary>
        /// Boss attacks player
        /// </summary>
        /// <param name="value"></param>
        public void AttackPlayer()
        {
            StartCoroutine(CurrentState.Attack(this, boss.bossData.attackPower));
        }

        public void AttackBoss()
        {
            ChangeStateTo(PlayerTurnState);
            StartCoroutine(CurrentState.Attack(this, attackingHero.saveData.attackPower));
        }

        public void AwaitingPlayerInput()
        {
            ChangeStateTo(WaitingForPlayerInput);
            StartCoroutine(CurrentState.Start());
            EventManager.EnableHeroToggles?.Invoke();
        }


        /// <summary>
        /// Has player won?
        /// </summary>
        /// <param name="value"></param>

        public void HasPlayerWon(bool hasWon)
        {
            if (hasWon)
            {
                StartCoroutine(CurrentState.Win(this));
            }
            else
            {
                StartCoroutine(CurrentState.Lose(this));
            }
        }

        /// <summary>
        /// Is hero dead?
        /// </summary>
        /// <param name="value"></param>

        public void HeroDeath()
        {
            StartCoroutine(CurrentState.Death(this));
        }

        public void SetHeroDeathState()
        {
            ChangeStateTo(PlayerLoseState);
            HasPlayerWon(false);
        }

        public void ChangeStateTo(State newState)
        {
            CurrentState = newState;
        }
        #endregion
    }
}

