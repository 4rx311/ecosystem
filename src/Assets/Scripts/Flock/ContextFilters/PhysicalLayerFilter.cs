using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Creatures.Components.FlockContextFilters
{
    /// <summary>
    ///     Detecting physical obstacles
    /// </summary>
    public class PhysicalLayerFilter : ContextFilter
    {
        public LayerMask mask;
        
        public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
        {
            var filtered = new List<Transform>();
            foreach (var item in original)
                if (mask == (mask | (1 << item.gameObject.layer)))
                    filtered.Add(item);
            return filtered;
        }
    }
}