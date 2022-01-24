using System;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
    public class Health : MonoBehaviour, IHealth
    {
        public float MaxHealth;
        public GameObject BlowUpFx;
        
        private float _currentHealth;

        private void Awake()
        {
            _currentHealth = MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        public void ResetHealth()
        {
            _currentHealth = MaxHealth;
        }

        private void Die()
        {
            Instantiate(BlowUpFx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}