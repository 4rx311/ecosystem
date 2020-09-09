using System;
using System.Collections.Generic;
using Behaviours.FlockBehaviours;
using UnityEngine;

namespace Assets.Scripts.Creatures.Components
{
    [RequireComponent(typeof(Collider2D))]
    public class FlockAgent : MonoBehaviour
    {
        public FlockBehaviour[] behaviors;
        
        public float[] weights;
        
        public FlockController AgentFlock { get; private set; }
        public Collider2D AgentCollider { get; private set; }
        public float SquareAvoidanceRadius { get; private set; }
        
        [Range(1f, 100f)] public float driveFactor = 10f;
        [Range(1f, 100f)] public float maxSpeed = 5f;
        [Range(1f, 10f)] public float neighborRadius = 1.5f;
        [Range(0f, 1f)] public float avoidanceRadiusMultiplier = 0.5f;
        
        private float squareMaxSpeed;
        private float squareNeighborRadius;

        private void Update()
        {
            var surrounding = GetNearbyObjects();
            var vector = ChooseBehaviour(surrounding);
            Move(vector);
        }

        private void Start()
        {
            squareMaxSpeed = maxSpeed * maxSpeed;
            squareNeighborRadius = neighborRadius * neighborRadius;
            SquareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
        }
        
        public void Move(Vector2 velocity)
        {
            velocity *= driveFactor;
            if (velocity.sqrMagnitude > squareMaxSpeed) 
                velocity = velocity.normalized * maxSpeed;
            
            transform.up = velocity;
            transform.position += (Vector3) velocity * Time.deltaTime;
        }
        
        private Vector2 ChooseBehaviour(List<Transform> surrounding)
        {
            //set up move
            var move = Vector2.zero;

            //iterate through behaviors
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

        public List<Transform> GetNearbyObjects()
        {
            var context = new List<Transform>();
            var contextColliders = Physics2D.OverlapCircleAll(transform.position, neighborRadius);
            foreach (var c in contextColliders)
                if (c != AgentCollider)
                    context.Add(c.transform);
            return context;
        }
    }
}