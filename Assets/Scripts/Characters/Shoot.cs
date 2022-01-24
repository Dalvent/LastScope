using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Shoot : MonoBehaviour
    {
        public List<Transform> ShootingFrom;
        public Projectile ProjectilePrefab;
        public float ReloadTime;
        public float BulletSpeed = 5;
        public float Damage = 5;

        private readonly List<Projectile> ActiveProjectile = new List<Projectile>();
        private int _projectileLayer;

        private void Awake()
        {
            _projectileLayer = GetProjectileLayer();
        }

        protected abstract int GetProjectileLayer();
        
        private void Start()
        {
            StartCoroutine(Shooting());
        }

        private void Update()
        {
            foreach (var projectile in ActiveProjectile)
            {
                projectile.transform.position += projectile.transform.rotation * Vector3.up * BulletSpeed * Time.deltaTime;

            }

            ActiveProjectile.RemoveAll(projectile =>
            {
                if ((projectile.transform.position - transform.position).sqrMagnitude > 25 * 25)
                {
                    Destroy(projectile.gameObject);
                    return true;
                }

                return false;
            });
        }

        private IEnumerator Shooting()
        {
            while (true)
            {
                yield return new WaitForSeconds(ReloadTime);

                foreach (var shootingFrom in ShootingFrom)
                {
                    Projectile projectileObject = Instantiate(ProjectilePrefab, shootingFrom.position, shootingFrom.rotation);
                    projectileObject.gameObject.layer = _projectileLayer;
                    var layer = LayerMask.LayerToName(_projectileLayer);
                    projectileObject.Damage = Damage;
                    ActiveProjectile.Add(projectileObject);
                }
            }
        }
    }
}