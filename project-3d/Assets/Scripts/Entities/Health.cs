using UnityEngine;

namespace Kp4wsGames.Entities
{
    public class Health : MonoBehaviour
    {
        private float currentHealth = 100f;

        public void TakeDamage(float amount)
        {
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                //Destroy(gameObject);
            }
        }

        public float GetHealth()
        {
            return currentHealth;
        }
    }
}