using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Creatures.Components.FlockContextFilters
{
    public abstract class ContextFilter : ScriptableObject
    {
        public abstract List<Transform> Filter(FlockAgent agent, List<Transform> original);
    }
}