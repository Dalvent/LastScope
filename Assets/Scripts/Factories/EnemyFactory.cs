using System;
using CodeBase.Services;
using DefaultNamespace.Factories.Pools;
using DefaultNamespace.StaticData;
using UnityEngine;

namespace DefaultNamespace.Factories
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly EnemyFacade.Factory _penusoidEnemyFactory;
        private readonly IStaticDataService _staticDataService;

        public EnemyFactory(EnemyFacade.Factory penusoidEnemyFactory, IStaticDataService staticDataService)
        {
            _penusoidEnemyFactory = penusoidEnemyFactory;
            _staticDataService = staticDataService;
        }
        
        public GameObject CreateEnemy(EnemyType enemyType, Vector3 position, Quaternion quaternion)
        {
            switch (enemyType)
            {
                case EnemyType.Penisoid:
                    return CreatePenisoid(position, quaternion);
                default:
                    throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null);
            }
        }

        private GameObject CreatePenisoid(Vector3 position, Quaternion quaternion)
        {
            EnemyStaticData penusoidData = _staticDataService.ForEnemy(EnemyType.Penisoid);

            EnemyFacade penusoid = _penusoidEnemyFactory.Create();
            penusoid.transform.position = position;
            penusoid.transform.rotation = quaternion;
            
            penusoid.Health.MaxHealth = penusoidData.MaxHealth;
            penusoid.Health.ResetHealth();

            penusoid.EnemyShoot.Damage = penusoidData.Damage;
            penusoid.EnemyShoot.BulletSpeed = penusoidData.BulletSpeed;
            penusoid.EnemyShoot.ReloadTime = penusoidData.ReloadTime;
            
            penusoid.EnemyMoveDirectly.Speed = penusoidData.Speed;

            return penusoid.gameObject;
        }
    }
}