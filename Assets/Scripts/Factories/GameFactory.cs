using System;
using LastScope.Characters;
using LastScope.Characters.Enemy;
using LastScope.Characters.Player;
using LastScope.Services;
using LastScope.StaticData;
using ModestTree;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace LastScope.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly DiContainer _diContainer;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;

        public GameFactory(DiContainer diContainer, IAssetProvider assetProvider, IStaticDataService staticDataService)
        {
            _diContainer = diContainer;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }
        
        public GameObject CreatePlayer(Transform parent)
        {
            GameObject prefab = _assetProvider.Load(AssetPath.Player);
            GameObject player = _diContainer.InstantiatePrefab(prefab, parent);

            PlayerStaticData playerData = _staticDataService.Player;
            
            Health healthComponent = player.GetComponent<Health>();
            healthComponent.MaxHealth = playerData.MaxHealth;
            healthComponent.ResetHealth();
            
            BulletShoot bulletShootComponent = player.GetComponent<BulletShoot>();
            bulletShootComponent.Damage = playerData.Damage;
            bulletShootComponent.ReloadTime = playerData.ReloadTime;
            bulletShootComponent.BulletSpeed = playerData.BulletSpeed;
            
            PlayerMove moveComponent = player.GetComponent<PlayerMove>();
            moveComponent.Speed = playerData.Speed;
            
            return player;
        }


        public GameObject CreateEnemy(EnemyStaticData enemyStaticData, Vector3 position, Quaternion quaternion)
        {
            return enemyStaticData.BehaviorType switch
            {
                BehaviorType.None => _diContainer.InstantiatePrefab(enemyStaticData.Prefab, position, quaternion, null),
                BehaviorType.MoveAndShoot => CreateMoveDirectionAndShoot(enemyStaticData, position, quaternion),
                _ => throw new ArgumentOutOfRangeException("BehaviorType is unown!")
            };
        }

        private GameObject CreateMoveDirectionAndShoot(EnemyStaticData enemyStaticData, Vector3 position, Quaternion quaternion)
        {
            GameObject moveAndShootEnemy = _diContainer.InstantiatePrefab(enemyStaticData.Prefab, position, quaternion, null);
            moveAndShootEnemy.transform.position = position;
            moveAndShootEnemy.transform.rotation = quaternion;

            Health health = moveAndShootEnemy.GetComponent<Health>();
            health.MaxHealth = enemyStaticData.MaxHealth;
            health.ResetHealth();

            BulletShoot enemyShoot = moveAndShootEnemy.GetComponent<BulletShoot>();
            enemyShoot.Damage = enemyStaticData.Damage;
            enemyShoot.BulletSpeed = enemyStaticData.BulletSpeed;
            enemyShoot.ReloadTime = enemyStaticData.ReloadTime;
            
            IEnemyMove enemyMove = moveAndShootEnemy.GetComponent<IEnemyMove>();
            enemyMove.Speed = enemyStaticData.Speed;

            return moveAndShootEnemy;
        }
    }
}