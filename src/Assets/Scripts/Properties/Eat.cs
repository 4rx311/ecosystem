using System;
using Assets.Scripts.Creatures.Components;
using UnityEngine;

namespace Properties
{
    public class Eat : MonoBehaviour
    {
        public string targetTagName;

        public int damageAmount = 10;

        private Metabolism _metabolism;
        private void Start()
        {
            _metabolism = GetComponent<Metabolism>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var food = collision.collider.GetComponent<Health>();
            if (food is null || !food.CompareTag(targetTagName))
                return;
            
            food.TakeDamage(damageAmount);
        }
    }
}