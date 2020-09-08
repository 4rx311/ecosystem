using System.Collections.Generic;
using System.Numerics;
using Assets.Scripts.Creatures;
using Assets.Scripts.Creatures.Components;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

namespace Assets.Scripts
{
    public class CreaturesSpawner : MonoBehaviour
    {
        //public GameObject carnivorePrefab;
        public FlockAgent herbivorePrefab;        
        public int carnivoreAmount;
        public int herbivoreAmount;
        public float creaturesDensity = 0.08f;
        
        private void Start()
        {
            SpawnHerbivores();
            //SpawnCarnivores();
        }

        public void SpawnHerbivores()
        {
            for (var i = 0; i < herbivoreAmount; i++)
                SpawnAgent(herbivorePrefab, herbivoreAmount);
        }

        private void SpawnAgent(FlockAgent agentPrefab, int creaturesCount)
        {
            var spawnPos = Random.insideUnitCircle * creaturesCount * creaturesDensity;
            var rotation = Quaternion.Euler(UnityEngine.Vector3.forward * Random.Range(0f, 360f));

            Instantiate(agentPrefab, spawnPos, rotation, transform);
        }
    }
}