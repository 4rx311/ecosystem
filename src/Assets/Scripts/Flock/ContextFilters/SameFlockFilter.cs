using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Creatures.Components.FlockContextFilters
{
    /// <summary>
    ///     Detecting other flock agents
    /// </summary>
    public class SameFilter : ContextFilter
    {
        public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
        {
            var filtered = new List<Transform>();
            foreach (var item in original)
            {
                var itemAgent = item.GetComponent<FlockAgent>();
                if (itemAgent != null && itemAgent.AgentFlock == agent.AgentFlock)
                    filtered.Add(item);
            }

            return filtered;
        }
    }
}