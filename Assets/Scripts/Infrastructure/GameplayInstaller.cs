using Cinemachine;
using CodeBase.Services;
using DefaultNamespace;
using DefaultNamespace.Factories;
using DefaultNamespace.Factories.Pools;
using DefaultNamespace.Factories.Pools.Projectile;
using DefaultNamespace.Logic;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        public GameFieldBounder GameFieldBounder;
        public DespawnArea DespawnArea;
        public CinemachineVirtualCamera MainCamera;

        public BulletProjectileFacade BulletPrefab;

        public override void InstallBindings()
        {
            BindPools();
            
            BindGameFieldService();
            BindCinemachineService();
            BindFactory();
            BindEnemyFactory();
            BindProjecileFactory();

            InitializeGameRunner();
        }

        private void BindPools()
        {
            IStaticDataService staticDataService = Container.Resolve<IStaticDataService>();

            Container.BindFactory<EnemyFacade, EnemyFacade.Factory>()
                .FromMonoPoolableMemoryPool(b => b
                    .WithInitialSize(10)
                    .FromComponentInNewPrefab(staticDataService.ForEnemy(EnemyType.Penisoid).Prefab));
            
            Container.BindFactory<BulletProjectileFacade, BulletProjectileFacade.Factory>()
                .FromMonoPoolableMemoryPool(b => b
                    .WithInitialSize(30)
                    .FromComponentInNewPrefab(BulletPrefab));
        }

        private void BindCinemachineService()
        {
            Container.Bind<ICinemachineService>()
                .FromInstance(new CinemachineService(MainCamera))
                .AsSingle();
        }

        private void InitializeGameRunner()
        {
            Container
                .Bind<IInitializable>()
                .To<GameRunner>()
                .AsSingle();
        }

        private void BindGameFieldService()
        {
            Container.Bind<IGameFieldService>()
                .FromInstance(new GameFieldService(GameFieldBounder, DespawnArea))
                .AsSingle();
        }

        private void BindFactory()
        {
            Container.Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle();
        }

        private void BindEnemyFactory()
        {
            Container.Bind<IEnemyFactory>()
                .To<EnemyFactory>()
                .AsSingle();
        }

        private void BindProjecileFactory()
        {
            Container.Bind<IProjectileFactory>()
                .To<ProjectileFactory>()
                .AsSingle();
        }
    }
}