using System;
using CodeBase.Services;
using DefaultNamespace.Factories.Pools.Projectile;
using DefaultNamespace.StaticData;
using UnityEngine;

namespace DefaultNamespace.Factories
{
    public class ProjectileFactory : IProjectileFactory
    {
        private const string PlayerProjectileLayer = "PlayerProjectile";
        private const string EnemyProjectileLayer = "EnemyProjectile";
        
        private readonly BulletProjectileFacade.Factory _bulletProjectileDespawn;

        public ProjectileFactory(BulletProjectileFacade.Factory bulletProjectileDespawn)
        {
            _bulletProjectileDespawn = bulletProjectileDespawn;
        }

        public GameObject CreateBullet(
            CharacterType creator, 
            float damage, 
            float speed,
            ProjectileCustomisationStaticData customisation,
            Vector3 position, 
            Quaternion rotation)
        {
            BulletProjectileFacade bullet = _bulletProjectileDespawn.Create();
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            bullet.transform.localScale = new Vector3(
                customisation.Width,
                customisation.Height,
                customisation.Width);
            
            bullet.ChangeMaterial(customisation.Material);
            bullet.OwnerType = creator;
            
            bullet.BulletProjectile.Damage = damage;
            bullet.BulletProjectile.Speed = speed;


            return bullet.gameObject;
        }
    }
}