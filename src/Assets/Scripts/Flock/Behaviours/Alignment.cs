using System.Collections.Generic;
using Assets.Scripts.Creatures.Components.FlockContextFilters;
using UnityEngine;

namespace Assets.Scripts.Creatures.Components.FlockBehaviours
{
    [CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
    public class Alignment : FilteredFlockBehaviour
    {
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> surrounding)
        {
            //if no neighbors, maintain current alignment
            if (surrounding.Count == 0)
                return agent.transform.up;

            //add all points together and average
            var alignmentMove = Vector2.zero;
            var filteredSurrounding = filter == null
                ? surrounding
                : filter.Filter(agent, surrounding);

            foreach (var item in filteredSurrounding)
                alignmentMove += (Vector2) item.transform.up;
            alignmentMove /= surrounding.Count;

            return alignmentMove;
        }
    }
}