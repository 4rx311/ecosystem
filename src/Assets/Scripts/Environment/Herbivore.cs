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

        private void FixedUpdate() => _stateMachine.DoOnTick();

        private void OnDestroy() => base.OnDestroy();

        private void Awake()
        {
            _stateMachine = new StateMachine();
            
            var search = new Search(this);
            var flee = new Flee(this, "Carnivore");
            
            _stateMachine.AddAnyTransition(flee, () => EnemyInRange());
            At(flee, search, () => EnemyInRange() == false);
            
            _stateMachine.SetState(search);
            
            void At(IState to, IState from, Func<bool> condition) =>
                _stateMachine.AddTransition(to, from, condition);
        }

        private bool EnemyInRange()
        {
            var enemy = FindClosestTarget("Carnivore");
            if (enemy == null)
                return false;
            float distanceToEnemy = Vector2.Distance(enemy.transform.position, transform.position);
            if (distanceToEnemy <= visionDistance)
                return true;

            return false;
        }
    }
}