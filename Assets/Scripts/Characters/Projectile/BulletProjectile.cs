using System;
using UnityEngine;

namespace LastScope.Characters.Projectile
{
    public class BulletProjectile : MonoBehaviour
    {
        public BulletProjectileFacade bulletProjectileFacade; 
        public float Damage { get; set; }
        public float Speed { get; set; }

        private int _gameAreaLayer;

        private void Awake()
        {
            _gameAreaLayer = LayerMask.NameToLayer("DespawnArea");
        }

        private void Update()
        {
            transform.position += transform.rotation * Vector3.up * Speed * Time.deltaTime;
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == _gameAreaLayer)
                return;
            
            if(!gameObject.activeSelf)
                return;
        
            other.gameObject.GetComponent<Health>().TakeDamage(Damage);
            bulletProjectileFacade.Dispose();
        }
    }
}
