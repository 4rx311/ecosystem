using UnityEngine;

namespace Assets.Scripts.Creatures
{
    public class EnvironmentSpawner : MonoBehaviour
    {
        public GameObject foodPrefab;
        public GameObject rockPrefab;        
        public int foodStartAmount;
        public int rockStartAmount;
        public float spawnRadius = 10f;

        private void Start()
        {
            SpawnFood();
            SpawnRocks();
        }

        public void SpawnFood()
        {
            for (var i = 0; i < foodStartAmount; i++)
                SpawnCreature(foodPrefab);
        }

        public void SpawnRocks()
        {
            for (var i = 0; i < rockStartAmount; i++)
                SpawnCreature(rockPrefab);
        }

        private void SpawnCreature(GameObject creaturePrefab)
        {
            var spawnPos = new Vector2();
            spawnPos += Random.insideUnitCircle.normalized;

            Instantiate(creaturePrefab, spawnPos, Quaternion.identity);
        } 
    }
}