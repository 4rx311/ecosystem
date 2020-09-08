using UnityEngine;

namespace Assets.Scripts.Creatures.Components
{
    public class Health : MonoBehaviour
    {
        public GameObject deathEffect;
        public int healthPoints;

        public virtual void Die()
        {
            var effect = Instantiate(deathEffect, transform.position, transform.rotation);
            effect.transform.localScale = transform.localScale;
            Destroy(effect, 10f);
            Destroy(gameObject);
        }

        public void TakeDamage(int amount)
        {
            healthPoints -= amount;

            if (healthPoints <= 0)
                Die();
        }
    }
}