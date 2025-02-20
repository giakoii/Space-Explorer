using UnityEngine;

namespace Enities
{
    public abstract class Entity : MonoBehaviour
    {
        public string EntityName { get; protected set; }
        public float Speed { get; protected set; }
        public int Health { get; set; }

        public int Score { get; set; }

        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health <= 0) Destroy(gameObject);
        }
        
        public virtual void AddScore(int amount)
        {
            Score += amount;
        }
    }
}