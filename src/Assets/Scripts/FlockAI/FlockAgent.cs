using System;
using System.Collections.Generic;
using Behaviours;
using Behaviours.FlockBehaviours;
using UnityEngine;

namespace Assets.Scripts.Creatures.Components
{
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Vision))]
    public class FlockAgent : MonoBehaviour
    {
        public FlockBehaviour[] behaviors;
        public float[] weights;
        
        [Range(1f, 10f)] public float neighborRadius = 1.5f;
        [Range(0f, 1f)] public float avoidanceRadiusMultiplier = 0.5f;
        
        public float SquareAvoidanceRadius { get; private set; }
        
        private Movement _movement;
        private Vision _vision;
        private float squareNeighborRadius;

        private void Start()
        {
            _movement = GetComponent<Movement>();
            _vision = GetComponent<Vision>();
            squareNeighborRadius = neighborRadius * neighborRadius;
            SquareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
        }
        
        private void Update()
        {
            var surrounding = _vision.GetNearbyObjects(neighborRadius);
            var vector = ChooseBehaviour(surrounding);
            _movement.Move(vector);
        }
        
        private Vector2 ChooseBehaviour(List<Transform> surrounding)
        {
            var move = Vector2.zero;

            for (var i = 0; i < behaviors.Length; i++)
            {
                var partialMove = behaviors[i].CalculateMove(this, surrounding) * weights[i];

                if (partialMove != Vector2.zero)
                {
                    if (partialMove.sqrMagnitude > weights[i] * weights[i])
                    {
                        partialMove.Normalize();
                        partialMove *= weights[i];
                    }

                    move += partialMove;
                }
            }

            return move;
        }
    }
}