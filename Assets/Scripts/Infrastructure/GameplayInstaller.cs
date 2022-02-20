using LastScope.Characters.Projectile;
using LastScope.Factories;
using LastScope.Logic.GameField;
using LastScope.Services;
using Zenject;

namespace LastScope.Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        public GameFieldFacade GameFieldFacade;
        public BulletProjectileFacade BulletPrefab;

        public override void InstallBindings()
        {
            BindPools();
            
            BindGameFieldFacade();
            BindFactory();
            BindProjecileFactory();

            InitializeGameRunner();
        }

        private void BindPools()
        {
            Container.BindFactory<BulletProjectileFacade, BulletProjectileFacade.Factory>()
                .FromMonoPoolableMemoryPool(b => b
                    .WithInitialSize(30)
                    .FromComponentInNewPrefab(BulletPrefab));
        }

        private void BindGameFieldFacade()
        {
            Container.Bind<IGameFieldFacade>()
                .FromInstance(GameFieldFacade)
                .AsSingle();
        }

        private void InitializeGameRunner()
        {
            Container
                .Bind<IInitializable>()
                .To<GameRunner>()
                .AsSingle();
        }

        private void BindFactory()
        {
            Container.Bind<IGameFactory>()
                .To<GameFactory>()
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