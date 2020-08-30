using Assets.Scripts.Creatures.States;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Creatures.States
{
    public class Flee : IState
    {
        private readonly Creature _fleeingCreature;
        private readonly string _targetTagName;

        public Flee(Creature fleeingCreature, string targetTagName)
        {
            _fleeingCreature = fleeingCreature;
            _targetTagName = targetTagName;
        }

        public void OnEnter()
        {
        }

        public void DoOnTick()
        {
            var away = GetRandomPoint();
            _fleeingCreature.MoveTo(away);
        }

        public void OnExit()
        {
        }

        private Vector3 GetRandomPoint()
        {
            var nearestCreaturePosition = GetNearestCraturePosition();
            var directionFromTarget = _fleeingCreature.transform.position - nearestCreaturePosition;

            var endPoint = _fleeingCreature.transform.position + (directionFromTarget * _fleeingCreature.visionDistance);
            return endPoint;
        }

        private Vector3 GetNearestCraturePosition()
        {
            var creature = _fleeingCreature.FindClosestTarget(_targetTagName);
            return creature?.transform.position ?? Vector3.zero;
        }
    }
}