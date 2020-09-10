using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Creatures.States
{
    public class Approach : IState
    {
        private readonly AnimalAgent _agent;
        private readonly string _targetTagName;

        public Approach(AnimalAgent agent, string targetTagName)
        {
            _agent = agent;
            _targetTagName = targetTagName;
        }

        public void OnEnter()
        {
            Debug.Log($"Enter state: {GetType().Name}");
        }

        public void DoOnTick()
        {
            var closest = _agent.vision.FindClosestTarget(_targetTagName);
            if(closest == null)
                return;
            Debug.Log($"move to pos: {closest.position}");
            var direction = closest.position - _agent.transform.position;
            _agent.movement.Move(direction);
        }

        public void OnExit()
        {
        }
    }
}