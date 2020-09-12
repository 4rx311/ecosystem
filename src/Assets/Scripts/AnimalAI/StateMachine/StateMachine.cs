using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Creatures.States
{
    public static class IStateExtensions
    {
        private static readonly Func<IState, bool > _checkActionCondition =
            state => state != Empty.Instance && state is object;
        
        public static void NotEmptyStateSelfAction(this IState state, Action<IState> action)
        {
            if (_checkActionCondition(state))
                action(state);
        }
        
        public static void NotEmptyStateSelfAction(this IState state, Action action)
        {
            if (_checkActionCondition(state))
                action();
        }
    }
    
    public partial class StateMachine
    {
        private IState _currentState = Empty.Instance;
        private readonly List<Transition> _transitions = new List<Transition>();

        public void AddTransition(IState from, IState to, Func<bool> predicate)
        {
            _transitions.Add(new Transition(from, to, predicate));

            //todo надо проверять что не добавляются одинаковые переходы?
        }

        public void OnTick()
        {
            var differentState = GetDifferentState();
            SetState(differentState);

            _currentState.NotEmptyStateSelfAction(_currentState.OnTick);
        }


        public void SetState(IState state)
        {
            if (_currentState == state)
                return;

            _currentState.NotEmptyStateSelfAction(_currentState.OnExit);
            _currentState = state;
            _currentState.NotEmptyStateSelfAction(_currentState.OnEnter);
        }

        private IState GetDifferentState()
        {
            var transitions = _transitions.Where(x => x.CheckCondition()).ToArray();
            if (transitions.Length > 1)
                throw new InvalidOperationException();

            var transitionState = transitions.FirstOrDefault()?.To;

            //todo сравнение IState идёт по ссылке на экземпляр - правильно ли это?
            return transitionState is object && transitionState != _currentState
                ? transitionState
                : Empty.Instance;
        }
    }
}