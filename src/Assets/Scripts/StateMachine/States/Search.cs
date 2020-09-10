using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Creatures.States
{
    public class Search : IState
    {
        private readonly Agent _searchingAgent;
        private DateTime _currentTime => DateTime.Now;
        private DateTime _previousTick;
        private const float _changeDirectionInterval = 1;

        public Search(Agent searchingAgent)
        {
            _previousTick = DateTime.Now;
            _searchingAgent = searchingAgent;
        }

        public void DoOnTick()
        {
            var passedTime = (_currentTime - _previousTick).TotalSeconds;
            if (passedTime > _changeDirectionInterval)
            {
                var randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                //_searchingAgent.MoveTo(randomDirection);
                _previousTick = DateTime.Now;
            }
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }
    }
}