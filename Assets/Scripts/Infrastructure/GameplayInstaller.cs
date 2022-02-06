using LastScope.Characters.Enemy;
using LastScope.Characters.Projectile;
using LastScope.Factories;
using LastScope.Logic;
using LastScope.Services;
using LastScope.Services.Game;
using Zenject;

namespace LastScope.Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        public GameFieldBounder GameFieldBounder;
        public DespawnArea DespawnArea;

        [Inject]
        public void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
        
        public BulletProjectileFacade BulletPrefab;
        private IStaticDataService _staticDataService;

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
                .FromInstance(new CinemachineService())
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