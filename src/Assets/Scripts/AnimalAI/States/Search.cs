using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Creatures.States
{
    public class Search : IState
    {
        private readonly AnimalAgent _searchingAgent;
        private DateTime _currentTime => DateTime.Now;
        private DateTime _previousTick;
        private const float _changeDirectionInterval = 1;
        private Vector2 _currentDirection; 

        public Search(AnimalAgent searchingAgent)
        {
            _previousTick = DateTime.Now;
            _searchingAgent = searchingAgent;
        }

        public void OnTick()
        {
            var passedTime = (_currentTime - _previousTick).TotalSeconds;
            if (passedTime > _changeDirectionInterval)
            {
                _currentDirection = _searchingAgent.movement.GetRandomDirection();
                _previousTick = DateTime.Now;
            }
            
            _searchingAgent.movement.Move(_currentDirection);
        }

        public void OnEnter()
        {
            Debug.Log($"Enter state: {this.GetType().Name}");
        }

        public void OnExit()
        {
        }
    }
}