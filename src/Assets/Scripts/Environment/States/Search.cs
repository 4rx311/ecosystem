using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Creatures.States
{
    public class Search : IState
    {
        private readonly Creature _searchingCreature;
        private DateTime _currentTime => DateTime.Now;
        private DateTime _previousTick;
        private const float _changeDirectionInterval = 1;

        public Search(Creature searchingCreature)
        {
            _previousTick = DateTime.Now;
            _searchingCreature = searchingCreature;
        }

        public void DoOnTick()
        {
            var passedTime = (_currentTime - _previousTick).TotalSeconds;
            if (passedTime > _changeDirectionInterval)
            {
                var randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                _searchingCreature.MoveTo(randomDirection);
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