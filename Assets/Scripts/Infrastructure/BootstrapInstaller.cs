using CodeBase.Services;
using DefaultNamespace.Factories;
using Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            BindInstallersInterface();
            
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

        private void BindInput()
        {
            Container.Bind<IInputService>()
                .To<CursorInputService>()
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