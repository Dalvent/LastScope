using LastScope.Services;
using LastScope.Services.Input;
using Zenject;

namespace LastScope.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            BindInstallersInterface();

            BindResolutionService();
            BindPlayerService();
            BindCameraService();
            BindInput();
            BindAssetProvider();
            BindSceneLoader();
            BindStaticDataService();
        }

        private void BindInstallersInterface()
        {
            Container.BindInterfacesTo<BootstrapInstaller>()
                .FromInstance(this)
                .AsSingle();
        }

        private void BindResolutionService()
        {
            Container.Bind<IResolutionService>()
                .To<ResolutionService>()
                .AsSingle();
        }

        private void BindPlayerService()
        {
            Container.Bind<IPlayerService>()
                .To<PlayerService>()
                .AsSingle();
        }

        private void BindCameraService()
        {
            Container.Bind<ICameraService>()
                .To<CameraService>()
                .AsSingle();
        }

        private void BindInput()
        {
            Container.Bind<IInputService>()
                .To<InputService>()
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
        }

        private void BindAssetProvider()
        {
            Container.Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle();
        }

        private void BindStaticDataService()
        {
            var staticDataService = new StaticDataService();
            staticDataService.Load();
            Container.Bind<IStaticDataService>()
                .FromInstance(staticDataService)
                .AsSingle();
        }
    }
}