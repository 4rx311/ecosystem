using Assets.Scripts.Creatures.States;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Creatures.States
{
    public class Flee : IState
    {
        private readonly AnimalAgent _fleeingAgent;
        private readonly string _targetTagName;

        public Flee(AnimalAgent fleeingAgent, string targetTagName)
        {
            _fleeingAgent = fleeingAgent;
            _targetTagName = targetTagName;
        }

        public void OnEnter()
        {
            Debug.Log($"Enter state: {this.GetType().Name}");
        }

        public void OnTick()
        {
            var away = GetRandomPoint();
            _fleeingAgent.movement.Move(away);
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
            var creature = _fleeingAgent.vision.FindClosestTarget(_targetTagName);
            return creature?.transform.position ?? Vector3.zero;
        }
    }
}