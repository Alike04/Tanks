using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class StateMachine
    {
        State _currentState;

        private readonly Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>();
        private List<Transition> _currentTransition = new List<Transition>();
        private readonly List<Transition> _anyTransition = new List<Transition>();

        private readonly static List<Transition> EmptyTransition = new List<Transition>(capacity: 0);

        public void Tick()
        {
            var transition = GetTransition();
            if (transition != null)
            {
                SetState(transition.To);
            }
            _currentState?.Tick();
        }
        public void SetState(State state)
        {
            if (_currentState == state)
                return;
            _currentState?.OnStateExit();
            _currentState = state;
            _transitions.TryGetValue(_currentState.GetType(), out _currentTransition);
            if (_currentTransition == null)
            {
                _currentTransition = EmptyTransition;
            }
            _currentState?.OnStateEnter();
        }
        public State GetCurrentState()
        {
            return _currentState;
        }
        public void AddTransition(State from, State to, Func<bool> condition)
        {
            if (_transitions.TryGetValue(from.GetType(), out var transitions) == false)
            {
                transitions = new List<Transition>();
                _transitions[from.GetType()] = transitions;
            }
            transitions.Add(new Transition(to, condition));
        }
        public void AddAnyTransition(State state, Func<bool> condition)
        {
            if (_anyTransition.Contains(new Transition(state, condition)))
                return;
            _anyTransition.Add(new Transition(state, condition));
        }

        private class Transition
        {
            public Func<bool> Condition { get; }
            public State To { get; }
            public Transition(State to, Func<bool> condition)
            {
                Condition = condition;
                To = to;
            }
        }
        private Transition GetTransition()
        {
            foreach (var transition in _anyTransition)
            {
                if (transition.Condition())
                {
                    return transition;
                }
            }
            foreach (var transition in _currentTransition)
            {
                if (transition.Condition())
                {
                    return transition;
                }
            }
            return null;
        }
    }
}

