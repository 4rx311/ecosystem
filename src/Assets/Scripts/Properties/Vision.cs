using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Creatures
{
    [RequireComponent(typeof(Collider2D))]
    public class Vision : MonoBehaviour
    {
        public float visionRadius = 1f;
        public Collider2D AgentCollider { get; private set; }

        public List<Transform> GetNearbyObjects() => GetNearbyObjects(visionRadius);
        public List<Transform> GetNearbyObjects(float radius)
        {
            var context = new List<Transform>();
            var contextColliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach (var c in contextColliders)
                if (c != AgentCollider)
                    context.Add(c.transform);
            return context;
        }
        
        public Transform FindClosestTarget(string tagName)
        {
            var surrounding = GetNearbyObjects();
            var filteredSurrounding = new List<Transform>();
            foreach (var item in surrounding)
                if (item.CompareTag(tagName))
                    filteredSurrounding.Add(item);
            
            if (filteredSurrounding.Count == 0)
                return null;
            
            var position = transform.position;
            var closest = filteredSurrounding
                .OrderBy(o => (o.transform.position - position).sqrMagnitude)
                .FirstOrDefault();
            
            return closest;
        }

        public bool TargetInRange(string tagName) => TargetInRange(tagName, visionRadius);
        public bool TargetInRange(string tagName, float visionDistance)
        {
            var target = FindClosestTarget(tagName);
            if (target is null)
                return false;
            var distanceToTarget = Vector2.Distance(target.transform.position, transform.position);
            return distanceToTarget <= visionDistance;
        }
    }
}