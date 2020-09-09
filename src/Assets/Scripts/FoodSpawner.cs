using UnityEngine;

namespace Assets.Scripts.Creatures
{
    public class EnvironmentSpawner : MonoBehaviour
    {
        public GameObject foodPrefab;
        public int foodStartAmount;
        public float spawnRadius = 10f;

        private void Start()
        {
            SpawnFood();
        }

        public void SpawnFood()
        {
            for (var i = 0; i < foodStartAmount; i++)
                SpawnFood(foodPrefab);
        }

        private void SpawnFood(GameObject creaturePrefab)
        {
            var spawnPos = new Vector2();
            spawnPos += Random.insideUnitCircle.normalized;

            Instantiate(creaturePrefab, spawnPos, Quaternion.identity);
        } 
    }
}