using System;

namespace Assets.Scripts.Creatures.States
{
    public partial class StateMachine
    {
        private class Transition
        {
            private readonly Func<bool> _condition;

            public Transition(IState from, IState to, Func<bool> condition)
            {
                From = from;
                To = to;
                _condition = condition;
            }

            public IState From { get; }
            public IState To { get; }

            public bool CheckCondition()
            {
                return _condition();
            }
        }
    }
}