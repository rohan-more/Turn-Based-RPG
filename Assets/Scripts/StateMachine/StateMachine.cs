using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.StateMachine
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State State;

        public abstract void SetState(State state);

        public State GetState()
        {
            return State;
        }
    }

}

