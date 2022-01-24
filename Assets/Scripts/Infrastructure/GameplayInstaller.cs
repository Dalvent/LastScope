using Cinemachine;
using CodeBase.Services;
using DefaultNamespace;
using DefaultNamespace.Factories;
using DefaultNamespace.Factories.Pools;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        public GameFieldBounder GameFieldBounder;
        public CinemachineVirtualCamera MainCamera;

        public override void InstallBindings()
        {
            BindPools();
            
            BindGameFieldService();
            BindCinemachineService();
            BindFactory();

            InitializeGameRunner();
        }

        private void BindPools()
        {
            IStaticDataService staticDataService = Container.Resolve<IStaticDataService>();
            
            Container.BindMemoryPool<PenusoidDespawn, PenusoidDespawn.Pool>()
                .WithInitialSize(5)
                .FromComponentInNewPrefab(staticDataService.ForEnemy(EnemyType.Penisoid).Prefab);
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
                .FromInstance(new GameFieldService(GameFieldBounder))
                .AsSingle();
        }

        private void BindFactory()
        {
            Container.Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle();
        }
    }
}