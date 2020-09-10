using UnityEngine;

namespace Assets.Scripts.Creatures.States
{
    public class Approach : IState
    {
        private readonly Agent _agent;
        private readonly string _targetTagName;

        public Approach(Agent agent, string targetTagName)
        {
            _agent = agent;
            _targetTagName = targetTagName;
        }

        public void OnEnter()
        {
        }

        public void DoOnTick()
        {
            var targetPosition = GetTargetPosition();
            //_agent.MoveTo(targetPosition);
        }

        public void OnExit()
        {
        }

        private Vector3 GetTargetPosition()
        {
            var target = _agent.FindClosestTarget(_targetTagName);
            return target?.transform.position ?? Vector3.zero;
        }

    }
}