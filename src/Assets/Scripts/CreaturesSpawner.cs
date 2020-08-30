using UnityEngine;

namespace Assets.Scripts
{
    public class CreaturesSpawner : MonoBehaviour
    {
        public GameObject carnivorePrefab;
        public GameObject herbivorePrefab;        
        public int carnivoreAmount;
        public int herbivoreAmount;
        public float spawnRadius = 10f;

        private void Start()
        {
            SpawnHerbivores();
            SpawnCarnivores();
        }

        public void SpawnHerbivores()
        {
            for (var i = 0; i < herbivoreAmount; i++)
                SpawnCreature(herbivorePrefab);
        }

        public void SpawnCarnivores()
        {
            for (var i = 0; i < carnivoreAmount; i++)
                SpawnCreature(carnivorePrefab);
        }

        private void SpawnCreature(GameObject creaturePrefab)
        {
            var spawnPos = new Vector2();
            spawnPos += Random.insideUnitCircle.normalized;

            Instantiate(creaturePrefab, spawnPos, Quaternion.identity);
        }
    }
}