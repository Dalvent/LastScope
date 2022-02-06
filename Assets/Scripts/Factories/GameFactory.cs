using LastScope.Characters;
using LastScope.Characters.Player;
using LastScope.Services;
using LastScope.StaticData;
using UnityEngine;
using Zenject;

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
            
            PlayerShoot shootComponent = player.GetComponent<PlayerShoot>();
            shootComponent.Damage = playerData.Damage;
            shootComponent.ReloadTime = playerData.ReloadTime;
            shootComponent.BulletSpeed = playerData.BulletSpeed;
            
            PlayerMove moveComponent = player.GetComponent<PlayerMove>();
            moveComponent.Speed = playerData.Speed;
            
            return player;
        }
    }
}