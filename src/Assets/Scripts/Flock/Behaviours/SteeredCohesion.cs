using System.Collections.Generic;
using Assets.Scripts.Creatures.Components;
using Assets.Scripts.Creatures.Components.FlockContextFilters;
using UnityEngine;

namespace Behaviours.FlockBehaviours
{
    [CreateAssetMenu(menuName = "Flock/Behavior/Steered Cohesion")]
    public class SteeredCohesion : FilteredFlockBehaviour
    {
        public float agentSmoothTime = 0.5f;
        private Vector2 currentVelocity;

        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> surrounding)
        {
            if (surrounding.Count == 0)
                return Vector2.zero;

            //add all points together and average
            var cohesionMove = Vector2.zero;
            var filteredSurrounding = filter == null 
                ? surrounding 
                : filter.Filter(agent, surrounding);
            
            foreach (var item in filteredSurrounding) 
                cohesionMove += (Vector2) item.position;
            cohesionMove /= surrounding.Count;

            //create offset from agent position
            cohesionMove -= (Vector2) agent.transform.position;
            cohesionMove = Vector2.SmoothDamp(
                agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);
            return cohesionMove;
        }
    }
}