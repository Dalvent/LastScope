using System.Collections;
using System.Collections.Generic;
using LastScope.Factories;
using LastScope.StaticData;
using UnityEngine;
using Zenject;

namespace LastScope.Characters.Shoot
{
    public class BulletShoot : MonoBehaviour, IShoot
    {
        public CharacterType CharacterType;
        public List<Transform> ShootingFrom;
        public float ReloadTime;
        public float BulletSpeed = 5;
        public float Damage = 5;

        public BulletCustomisation BulletCustomisation;

        private IProjectileFactory _projectileFactory;

        [Inject]
        public void Construct(IProjectileFactory projectileFactory)
        {
            _projectileFactory = projectileFactory;
        }


        private void Start()
        {
            StartCoroutine(Shooting());
        }

        public virtual void Upgrade(int power = 1)
        {
        }

        private IEnumerator Shooting()
        {
            while (true)
            {
                yield return new WaitForSeconds(ReloadTime);

                foreach (Transform shotPoint in ShootingFrom)
                {
                    CreateProjectile(shotPoint.position, shotPoint.rotation);
                }
            }
        }

        protected virtual void CreateProjectile(Vector3 position, Quaternion rotation)
        {
            _projectileFactory.CreateBullet(CharacterType,
                Damage,
                BulletSpeed,
                BulletCustomisation,
                position,
                rotation);
        }
    }
}