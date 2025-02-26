using UnityEngine;

namespace Components
{
    public class Health : MonoBehaviour
    {
        public int maxHealth = 100;
        private int currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0) Destroy(gameObject);
        }
    }
}