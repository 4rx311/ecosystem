using System.Collections.Generic;
using Assets.Scripts.Creatures.Components;
using UnityEngine;

namespace Behaviours.FlockBehaviours
{
    public abstract class FlockBehaviour : ScriptableObject
    {
        public abstract Vector2 CalculateMove(FlockAgent agent, List<Transform> surrounding);
    }
}