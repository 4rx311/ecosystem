using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Creatures.Components;
using Assets.Scripts.Creatures.Components.FlockContextFilters;
using UnityEngine;

namespace Behaviours.FlockBehaviours
{
    [CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
    public class Cohesion : FilteredFlockBehaviour
    {
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> surrounding)
        {
            if (surrounding.Count == 0)
                return Vector2.zero;

            Vector2 cohesionMove = Vector2.zero;
            List<Transform> filteredSurrounding = filter == null
                ? surrounding
                : filter.Filter(agent, surrounding);

            foreach (var item in filteredSurrounding)
                cohesionMove += (Vector2) item.position;
            cohesionMove /= surrounding.Count;

            cohesionMove -= (Vector2) agent.transform.position;
            return cohesionMove;
        }
    }
}