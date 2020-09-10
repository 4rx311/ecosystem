using UnityEngine;

namespace Assets.Scripts.Creatures
{
    public class FoodSpawner : MonoBehaviour
    {
        public GameObject foodPrefab;
        public int foodStartAmount;
        public float spawnRadius = 7f;
        [Range(0f,1f)]public float density = 1f;
        
        private void Start()
        {
            SpawnFood();
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