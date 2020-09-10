using System;

namespace Assets.Scripts.Creatures.States
{
    public partial class StateMachine
    {
        private class Transition
        {
            public bool IsEmpty;

            public Transition(IState to, Func<bool> condition)
            {
                To = to;
                Condition = condition;
            }

            public Func<bool> Condition { get; }

            public IState To { get; }

            public static Transition CreateEmpty()
            {
                return new Transition(null, null)
                {
                    IsEmpty = true
                };
            }
        }
    }
}