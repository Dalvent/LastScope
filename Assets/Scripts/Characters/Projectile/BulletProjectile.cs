using UnityEngine;

namespace LastScope.Characters.Projectile
{
    public class BulletProjectile : MonoBehaviour
    {
        public BulletProjectileFacade bulletProjectileFacade;
        public float Damage { get; set; }
        public float Speed { get; set; }

        private void Update()
        {
            transform.position += transform.rotation * Vector3.up * Speed * Time.deltaTime;
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!gameObject.activeSelf)
                return;
        
            other.gameObject.GetComponent<IHealth>().TakeDamage(Damage);
            bulletProjectileFacade.Dispose();
        }
    }
}
