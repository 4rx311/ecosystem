using System;
using System.Collections.Generic;
using Assets.Scripts.Creatures.States;
using UnityEngine;

namespace Assets.Scripts.Creatures
{
    public class Herbivore : Creature
    {
        private static List<Rigidbody2D> _creaturesRbs;
        private StateMachine _stateMachine;
        private Vector2 _velocity;

        private void Start() => base.Start();

        private void Update() => _stateMachine.DoOnTick();

        private void OnDestroy() => base.OnDestroy();

        private void Awake()
        {
            _stateMachine = new StateMachine();
            
            var search = new Search(this);
            var approach = new Approach(this, "HerbFood");
            var flee = new Flee(this, "Carnivore");
            
            _stateMachine.AddAnyTransition(flee, () => TargetInRange("Carnivore"));
            At(flee, search, () => !TargetInRange("Carnivore"));
            //At(search, approach, () => TargetInRange("HerbFood"));

            _stateMachine.SetState(search);
            
            void At(IState from, IState to, Func<bool> condition) =>
                _stateMachine.AddTransition(from, to, condition);
        }

    }
}