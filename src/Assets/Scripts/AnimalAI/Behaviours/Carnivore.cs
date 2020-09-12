using System;
using System.Collections.Generic;
using Assets.Scripts.Creatures.States;
using UnityEngine;

namespace Assets.Scripts.Creatures
{
    public class Carnivore : AnimalAgent
    {
        private StateMachine _stateMachine;
        
        private const string _tagHerbivore = "Herbivore";
        private const string _tagMeat = "Meat";

        private void Start()
        {
            base.Init();
        }

        private void Awake()
        {
            _stateMachine = new StateMachine();
            
            var search = new Search(this);
            var approach = new Approach(this, _tagHerbivore);
            
            At(search, approach, () => vision.TargetInRange(_tagHerbivore));
            At(approach, search, () => !vision.TargetInRange(_tagHerbivore));
            
            _stateMachine.SetState(search);
            
            void At(IState from, IState to, Func<bool> condition) =>
                _stateMachine.AddTransition(from, to, condition);
        }

        private void Update() => _stateMachine.OnTick();

    }
}