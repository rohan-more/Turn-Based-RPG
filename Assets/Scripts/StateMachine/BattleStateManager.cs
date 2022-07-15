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
        public HeroDead PlayerDeadState = new HeroDead();
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

        public override void SetState(State state)
        {
            CurrentState = state;
        }
        /// <summary>
        /// Boss attacks player
        /// </summary>
        /// <param name="value"></param>
        public void AttackPlayer()
        {
            StartCoroutine(CurrentState.Execute(this));
        }

        public void AttackBoss()
        {
            SetState(PlayerTurnState);
            StartCoroutine(CurrentState.Execute(this));
        }

        public void AwaitingPlayerInput()
        {
            SetState(WaitingForPlayerInput);
            StartCoroutine(CurrentState.Enter());
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
                StartCoroutine(CurrentState.Execute(this));
                EventManager.PlayerWon?.Invoke(true);
            }
            else
            {
                StartCoroutine(CurrentState.Execute(this));
                EventManager.PlayerWon?.Invoke(false);
            }
        }

        /// <summary>
        /// Is hero dead?
        /// </summary>
        /// <param name="value"></param>

        public void HeroDeath()
        {
            StartCoroutine(CurrentState.Execute(this));
            EventManager.HeroDead?.Invoke();
        }

        public void SetHeroDeathState()
        {
            SetState(PlayerLoseState);
            HasPlayerWon(false);
        }

        #endregion
    }
}

