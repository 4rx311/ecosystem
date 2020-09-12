using System;
using System.Collections.Generic;
using Assets.Scripts.Creatures.States;
using UnityEngine;

namespace Assets.Scripts.Creatures
{
    public class Herbivore : AnimalAgent
    {
        private StateMachine _stateMachine;
        
        private const string _tagCarnivore = "Carnivore";
        private const string _tagHerbFood = "HerbFood";

        private void Start()
        {
            base.Init();
        }

        private void Awake()
        {
            _stateMachine = new StateMachine();
            
            var search = new Empty();
            var approach = new Approach(this, _tagHerbFood);
            var flee = new Flee(this, _tagCarnivore);
            
            //_stateMachine.AddAnyTransition(flee, () => vision.TargetInRange(_tagCarnivore));
            At(search, flee, () => !vision.TargetInRange(_tagCarnivore));
            At(flee, search, () => !vision.TargetInRange(_tagCarnivore));
            At(search, approach, () => vision.TargetInRange(_tagHerbFood));
            //At(approach, search, () => !vision.TargetInRange(_tagHerbFood));

            _stateMachine.SetState(search);
            
            void At(IState from, IState to, Func<bool> condition) =>
                _stateMachine.AddTransition(from, to, condition);
        }

        private void Update() => _stateMachine.OnTick();
    }
}