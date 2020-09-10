using Assets.Scripts.Creatures.States;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Creatures.States
{
    public class Flee : IState
    {
        private readonly Agent _fleeingAgent;
        private readonly string _targetTagName;

        public Flee(Agent fleeingAgent, string targetTagName)
        {
            _fleeingAgent = fleeingAgent;
            _targetTagName = targetTagName;
        }

        public void OnEnter()
        {
        }

        public void DoOnTick()
        {
            var away = GetRandomPoint();
            //_fleeingAgent.MoveTo(away);
        }

        public void OnExit()
        {
        }

        private Vector3 GetRandomPoint()
        {
            var nearestCreaturePosition = GetNearestCraturePosition();
            var directionFromTarget = _fleeingAgent.transform.position - nearestCreaturePosition;

            var endPoint = _fleeingAgent.transform.position + (directionFromTarget /* _fleeingAgent.visionDistance*/);
            return endPoint;
        }

        private Vector3 GetNearestCraturePosition()
        {
            var creature = _fleeingAgent.FindClosestTarget(_targetTagName);
            return creature?.transform.position ?? Vector3.zero;
        }
    }
}