using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public abstract class State
    {
        public abstract void OnStateEnter();
        public abstract void Tick();
        public abstract void OnStateExit();
    }
}

