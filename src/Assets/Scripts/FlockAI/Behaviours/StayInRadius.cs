using System.Collections.Generic;
using Assets.Scripts.Creatures.Components;
using UnityEngine;

namespace Behaviours.FlockBehaviours
{
    [CreateAssetMenu(menuName = "Flock/Behavior/Stay In Radius")]
    public class StayInRadius : FlockBehaviour
    {
        public Vector2 center;
        public float radius = 15f;

        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> surrounding)
        {
            var centerOffset = center - (Vector2) agent.transform.position;
            var t = centerOffset.magnitude / radius;
            if (t < 0.9f) return Vector2.zero;

            return centerOffset * t * t;
        }
    }
}