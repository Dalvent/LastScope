using LastScope.Characters;
using LastScope.Characters.Projectile;
using LastScope.StaticData;
using UnityEngine;

namespace LastScope.Factories
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly BulletProjectileFacade.Factory _bulletProjectileDespawn;

        public ProjectileFactory(BulletProjectileFacade.Factory bulletProjectileDespawn)
        {
            _bulletProjectileDespawn = bulletProjectileDespawn;
        }

        public GameObject CreateBullet(
            CharacterType creator, 
            float damage, 
            float speed,
            BulletCustomisation customisation,
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