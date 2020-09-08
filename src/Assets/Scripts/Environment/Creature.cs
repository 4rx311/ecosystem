﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Creatures
{
    public abstract class Creature : MonoBehaviour
    {
        public GameObject deathEffect;

        public int health;
        public int speed;
        public int maxSpeed;
        
        [Range(0f, 1f)] public float turnSpeed = .1f;
        
        public float visionDistance = 1f;
        public float repelAmount = 1f;
        public float repelRange = .5f;

        [HideInInspector] public GameObject currentTarget;

        private Rigidbody2D _rigidbody;
        private static List<Rigidbody2D> _creaturesRbs;
        
        protected void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            if(_creaturesRbs == null)
                _creaturesRbs = new List<Rigidbody2D>();
                    
            _creaturesRbs.Add(_rigidbody);
        }
        
        protected void OnDestroy()
        {
            _creaturesRbs.Remove(_rigidbody);
        }
        
        public void TakeDamage(int amount)
        {
            health -= amount;

            if (health <= 0)
                Die();
        }

        public void MoveTo(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            _rigidbody.rotation = angle;

            _rigidbody.AddForce(direction * speed, ForceMode2D.Force);
        }

        public virtual void Die()
        {
            var effect = Instantiate(deathEffect, transform.position, transform.rotation);
            effect.transform.localScale = transform.localScale;
            Destroy(effect, 10f);
            Destroy(gameObject);
        }

        public GameObject FindClosestTarget(string targetTagName)
        {
            var position = transform.position;
            return GameObject.FindGameObjectsWithTag(targetTagName)
                .OrderBy(o => (o.transform.position - position).sqrMagnitude)
                .FirstOrDefault();
        }

        public bool TargetInRange(string tagName)
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