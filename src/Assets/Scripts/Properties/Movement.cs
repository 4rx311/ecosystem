using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Behaviours
{
    public class Movement : MonoBehaviour
    {
        [Range(1f, 100f)] public float driveFactor = 10f;
        [Range(1f, 100f)] public float maxSpeed = 5f;
        
        private float squareMaxSpeed;

        private void Start()
        {
            squareMaxSpeed = maxSpeed * maxSpeed;
        }

        public void Move(Vector2 velocity)
        {
            velocity *= driveFactor;
            if (velocity.sqrMagnitude > squareMaxSpeed) 
                velocity = velocity.normalized * maxSpeed;
            
            transform.up = velocity;
            transform.position += (Vector3) velocity * Time.deltaTime;
        }

        public Vector2 GetRandomDirection()
        {
            float angle = Random.Range(-Mathf.PI, Mathf.PI);
            //var randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            var newDir = Mathf.Sin(angle) * Vector3.up + Mathf.Cos(angle) * Vector3.right;
            return newDir;
            //Move(newDir - transform.position);
        }
    }
}