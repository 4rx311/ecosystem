using System.Collections.Generic;
using System.Numerics;
using Assets.Scripts.Creatures;
using Assets.Scripts.Creatures.Components;
using UnityEngine;
using UnityEngine.Serialization;
using Quaternion = UnityEngine.Quaternion;

namespace Assets.Scripts
{
    public class CreaturesSpawner : MonoBehaviour
    {
        public GameObject carnivorePrefab;
        public GameObject herbivorePrefab;        
        public int carnivoreAmount;
        public int herbivoreAmount;
        public float spawnRadius = 5f;
        [Range(0f,1f)]public float density = 1f;
        
        private void Start()
        {
            SpawnHerbivores();
            SpawnCarnivores();
        }

        public void SpawnHerbivores()
        {
            for (var i = 0; i < herbivoreAmount; i++)
                SpawnAgent(herbivorePrefab);
        }
        
        public void SpawnCarnivores()
        {
            for (var i = 0; i < carnivoreAmount; i++)
                SpawnAgent(carnivorePrefab);
        }
        
        private void SpawnAgent(GameObject agentPrefab)
        {
            var spawnPos = Random.insideUnitCircle * spawnRadius * density;
            var rotation = Quaternion.Euler(UnityEngine.Vector3.forward * Random.Range(0f, 360f));

            Instantiate(agentPrefab, spawnPos, rotation, transform);
        }
    }
}