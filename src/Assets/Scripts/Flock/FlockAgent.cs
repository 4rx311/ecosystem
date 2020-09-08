using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Creatures.Components
{
    [RequireComponent(typeof(Collider2D))]
    public class FlockAgent : MonoBehaviour
    {
        public FlockController AgentFlock { get; private set; }
        public Collider2D AgentCollider { get; private set; }
        public float SquareAvoidanceRadius { get; private set; }
        
        [Range(1f, 100f)] public float driveFactor = 10f;
        [Range(1f, 100f)] public float maxSpeed = 5f;
        [Range(1f, 10f)] public float neighborRadius = 1.5f;
        [Range(0f, 1f)] public float avoidanceRadiusMultiplier = 0.5f;
        
        private float squareMaxSpeed;
        private float squareNeighborRadius;

        private void Start()
        {
            squareMaxSpeed = maxSpeed * maxSpeed;
            squareNeighborRadius = neighborRadius * neighborRadius;
            SquareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
        }
        
        public void AttachToFlock(FlockController flock)
        {
            AgentFlock = flock;
        }

        public void Move(Vector2 velocity)
        {
            velocity *= driveFactor;
            if (velocity.sqrMagnitude > squareMaxSpeed) 
                velocity = velocity.normalized * maxSpeed;
            
            transform.up = velocity;
            transform.position += (Vector3) velocity * Time.deltaTime;
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