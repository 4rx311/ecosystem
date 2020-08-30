using UnityEngine;

namespace Assets.Scripts.Creatures.States
{
    public class Approach : IState
    {
        private readonly Creature _creature;
        private readonly string _targetTagName;

        public Approach(Creature creature, string targetTagName)
        {
            _creature = creature;
            _targetTagName = targetTagName;
        }

        public void OnEnter()
        {
        }

        public void DoOnTick()
        {
            var targetPosition = GetTargetPosition();
            _creature.MoveTo(targetPosition);
        }

        public void OnExit()
        {
        }

        private Vector3 GetTargetPosition()
        {
            return new Vector3();
        }

    }
}