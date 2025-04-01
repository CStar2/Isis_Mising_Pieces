using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagasLib.StateMachine
{
    public class StateMachine
    {
        protected IState CurrentState;
        private IState _previousState;

        private readonly Dictionary<Type, List<Transition>> _transitions = new();
        private List<Transition> _currentTransitions = new();
        private readonly List<Transition> _anyTransitions = new();
        private static readonly List<Transition> EmptyTransitions = new(0);

        
        public Type GetCurrentStateType()
        {
            return CurrentState.GetType();
        }
        
        public Type GetPreviousStateType()
        {
            if (_previousState == null)
                return CurrentState.GetType();
            return _previousState.GetType();
        }

        public void Tick()
        {
            var transition = GetTransition();
            if (transition != null)
                SetState(transition.To);

            CurrentState?.Tick();
        }

        public void PhysicsTick()
        {
            CurrentState?.PhysicsTick();
        }

        public void SetState(IState state)
        {
            if (state == CurrentState)
                return;

            CurrentState?.OnExit();
            _previousState = CurrentState;
            CurrentState = state;

            _transitions.TryGetValue(CurrentState.GetType(), out _currentTransitions);
            if (_currentTransitions == null)
                _currentTransitions = EmptyTransitions;

            CurrentState.OnEnter();
        }

        public void AddTransition(IState from, IState to, Func<bool> predicate)
        {
            if (_transitions.TryGetValue(from.GetType(), out var transitions) == false)
            {
                transitions = new List<Transition>();
                _transitions[from.GetType()] = transitions;
            }

            transitions.Add(new Transition(to, predicate));
        }

        public void AddAnyTransition(IState state, Func<bool> predicate)
        {
            _anyTransitions.Add(new Transition(state, predicate));
        }

        private class Transition
        {
            public Func<bool> Condition { get; }
            public IState To { get; }

            public Transition(IState to, Func<bool> condition)
            {
                To = to;
                Condition = condition;
            }
        }

        private Transition GetTransition()
        {
            foreach (var transition in _anyTransitions)
                if (transition.Condition())
                    return transition;

            foreach (var transition in _currentTransitions)
                if (transition.Condition())
                    return transition;

            return null;
        }

        public void OnAnimationEnterEvent()
        {
            CurrentState?.OnAnimationEnterEvent();
        }

        public void OnAnimationExitEvent()
        {
            CurrentState?.OnAnimationExitEvent();
        }

        public void OnAnimationTransitionEvent()
        {
            CurrentState?.OnAnimationTransitionEvent();
        }

        public void OnTriggerEnterEvent(Collider other)
        {
            CurrentState?.OnTriggerEnterEvent(other);
        }

        public void OnTriggerExitEvent(Collider other)
        {
            CurrentState?.OnTriggerExitEvent(other);
        }
    }
}
