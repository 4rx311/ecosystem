using System;
using UnityEngine;

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
    }
}