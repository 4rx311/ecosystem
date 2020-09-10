using System;
using Behaviours;
using UnityEngine;

namespace Assets.Scripts.Creatures
{
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Vision))]
    public abstract class AnimalAgent : MonoBehaviour
    {
        
        [HideInInspector] public Movement movement;
        [HideInInspector] public Vision vision;

        protected void Init()
        {
            movement = GetComponent<Movement>();
            vision = GetComponent<Vision>();
        }
    }
}