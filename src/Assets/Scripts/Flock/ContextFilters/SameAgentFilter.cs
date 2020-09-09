using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Creatures.Components.FlockContextFilters
{
    /// <summary>
    ///     Detecting other flock agents
    /// </summary>
    [CreateAssetMenu(menuName = "Flock/Filters/Same Agent Filter")]  
    public class SameAgentFilter : ContextFilter
    {
        public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
        {
            var filtered = new List<Transform>();
            foreach (var item in original)
            {
                var itemAgent = item.GetComponent<FlockAgent>();
                if (itemAgent != null && itemAgent.tag == agent.tag)
                    filtered.Add(item);
            }

            return filtered;
        }
    }
}