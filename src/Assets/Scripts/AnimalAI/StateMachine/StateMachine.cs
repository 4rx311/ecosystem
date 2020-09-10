using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Creatures.States
{
    public partial class StateMachine
    {
        private static readonly List<Transition> EmptyTransitions = new List<Transition>(0);
        private readonly List<Transition> _anyTransitions = new List<Transition>();
        private IState _currentState;
        private List<Transition> _currentTransitions = new List<Transition>();

        private readonly Dictionary<Type, List<Transition>> _transitions =
            new Dictionary<Type, List<Transition>>();

        public void DoOnTick()
        {
            var transition = GetTransition();
            if (!transition.IsEmpty)
                SetState(transition.To);

            _currentState?.DoOnTick();
        }

        public void SetState([NotNull] IState state)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));

            if (state == _currentState)
                return;

            _currentState?.OnExit();
            _currentState = state;

            _transitions.TryGetValue(_currentState.GetType(), out _currentTransitions);
            if (_currentTransitions == null)
                _currentTransitions = EmptyTransitions;

            _currentState.OnEnter();
        }

        public void AddTransition(IState from, IState to, Func<bool> predicate)
        {
            if (_transitions.TryGetValue(from.GetType(),
                out var transitions) == false)
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

        private Transition GetTransition()
        {
            foreach (var transition in _anyTransitions)
                if (transition.Condition())
                    return transition;

            foreach (var transition in _currentTransitions)
                if (transition.Condition())
                    return transition;

            return Transition.CreateEmpty();
        }
    }
}