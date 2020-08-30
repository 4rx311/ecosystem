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
        private const float _changeDirectionInterval = 2;

        public Search(Creature searchingCreature)
        {
            _previousTick = DateTime.Now;
            _searchingCreature = searchingCreature;
        }

        public void DoOnTick()
        {
            if ((_currentTime - _previousTick).TotalSeconds > _changeDirectionInterval)
            {
                var randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                _searchingCreature.MoveTo(randomDirection);
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