using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Creatures
{
    public class FoodSpawner : MonoBehaviour
    {
        public GameObject foodPrefab;
        public int foodStartAmount;
        public float spawnRadius = 7f;
        [Range(0f,1f)]public float density = 1f;
        public float spawnDelay = 10000f;
        
        private DateTime _currentTime => DateTime.Now;
        private DateTime _previousTick;
        
        private void Start()
        {
            SpawnFood();
        }

        private void FixedUpdate()
        {
            var passedTime = (_currentTime - _previousTick).TotalSeconds;
            if (passedTime < spawnDelay) 
                return;
            
            SpawnFood();
            _previousTick = DateTime.Now;
        }

        public void SpawnFood()
        {
            for (var i = 0; i < foodStartAmount; i++)
                SpawnFood(foodPrefab);
        }

        private void SpawnFood(GameObject agentPrefab)
        {
            var spawnPos = Random.insideUnitCircle * spawnRadius * density;
            var rotation = Quaternion.Euler(UnityEngine.Vector3.forward * Random.Range(0f, 360f));

            Instantiate(agentPrefab, spawnPos, rotation, transform);
        }
    }
}