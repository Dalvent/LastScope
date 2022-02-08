using System;
using UnityEngine;

namespace LastScope.Characters
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;
        public GameObject BlowUpFx;
        
        private float _currentHealth;

        public event Action Died;
        
        public float MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }
        
        private void Awake()
        {
            ResetHealth();
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
            _currentHealth = _maxHealth;
        }

        private void Die()
        {
            Died?.Invoke();
            
            var blowUp = Instantiate(BlowUpFx, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(blowUp, 10);
            
        }
    }
}