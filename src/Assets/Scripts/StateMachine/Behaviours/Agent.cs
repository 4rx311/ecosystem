using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Creatures
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Agent : MonoBehaviour
    {
        public Collider2D AgentCollider { get; private set; }
        
        public List<Transform> GetNearbyObjects(float radius)
        {
            var context = new List<Transform>();
            var contextColliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach (var c in contextColliders)
                if (c != AgentCollider)
                    context.Add(c.transform);
            return context;
        }
        
        public GameObject FindClosestTarget(string targetTagName)
        {
            var position = transform.position;
            return GameObject.FindGameObjectsWithTag(targetTagName)
                .OrderBy(o => (o.transform.position - position).sqrMagnitude)
                .FirstOrDefault();
        }

        public bool TargetInRange(string tagName, float visionDistance)
        {
            var target = FindClosestTarget(tagName);
            if (target == null)
                return false;
            float distanceToTarget = Vector2.Distance(target.transform.position, transform.position);
            if (distanceToTarget <= visionDistance)
                return true;

            return false;
        }
    }
}