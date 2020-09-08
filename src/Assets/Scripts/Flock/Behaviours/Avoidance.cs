using System.Collections.Generic;
using Assets.Scripts.Creatures.Components;
using Assets.Scripts.Creatures.Components.FlockContextFilters;
using UnityEngine;

namespace Behaviours.FlockBehaviours
{
    [CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
    public class Avoidance : FilteredFlockBehaviour
    {
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> surrounding)
        {
            //if no neighbors, return no adjustment
            if (surrounding.Count == 0)
                return Vector2.zero;

            //add all points together and average
            Vector2 avoidanceMove = Vector2.zero;
            int nAvoid = 0;
            List<Transform> filteredSurrounding = filter == null
                ? surrounding 
                : filter.Filter(agent, surrounding);
            
            foreach (Transform item in filteredSurrounding)
            {
                if (Vector2.SqrMagnitude(item.position - agent.transform.position) < agent.SquareAvoidanceRadius)
                {
                    nAvoid++;
                    avoidanceMove += (Vector2)(agent.transform.position - item.position);
                }
            }
            if (nAvoid > 0)
                avoidanceMove /= nAvoid;

            return avoidanceMove;
        }
    }
}