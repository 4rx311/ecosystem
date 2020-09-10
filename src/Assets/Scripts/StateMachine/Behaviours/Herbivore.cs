using System;
using System.Collections.Generic;
using Assets.Scripts.Creatures.States;
using UnityEngine;

namespace Assets.Scripts.Creatures
{
    public class Herbivore : Agent
    {
        private static List<Rigidbody2D> _creaturesRbs;
        private StateMachine _stateMachine;
        private Vector2 _velocity;

        public float viewDistance = 1f;
        
        private void Update() => _stateMachine.DoOnTick();

        private void Awake()
        {
            _stateMachine = new StateMachine();
            
            var search = new Search(this);
            var approach = new Approach(this, "HerbFood");
            var flee = new Flee(this, "Carnivore");
            
            _stateMachine.AddAnyTransition(flee, () => TargetInRange("Carnivore", viewDistance));
            At(flee, search, () => !TargetInRange("Carnivore", viewDistance));
            At(search, approach, () => TargetInRange("HerbFood", viewDistance));
            At(approach, search, () => !TargetInRange("HerbFood", viewDistance));

            _stateMachine.SetState(search);
            
            void At(IState from, IState to, Func<bool> condition) =>
                _stateMachine.AddTransition(from, to, condition);
        }

    }
}