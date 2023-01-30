using Data;
using Infrastructure.Services;
using Infrastructure.Services.Ads;
using Infrastructure.Services.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.Sound;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.Theme;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Scenes.Initial.GetDescription(), EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadProgressState>();
        }

        private void RegisterServices()
        {
            RegisterStaticData();

            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterSingle<IUIFactoryService>(new IuiFactoryService(_services.Single<IStaticDataService>(), _services.Single<IPersistentProgressService>()));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>()));
            _services.RegisterSingle<IAdsService>(new AdsService());
            _services.RegisterSingle<ISoundService>(new SoundService(_services.Single<IStaticDataService>()));

            RegisterThemeService();
        }

        private void RegisterStaticData()
        {
            _services.RegisterSingle<IStaticDataService>(new StaticDataService());
            _services.Single<IStaticDataService>().Load();
        }
        
        private void RegisterThemeService()
        {
            _services.RegisterSingle<IThemeService>(new ThemeService(_services.Single<IStaticDataService>()));
            _services.Single<ISaveLoadService>().RegisterAllLife((ISavedProgressReader)_services.Single<IThemeService>());
        }
    }
}