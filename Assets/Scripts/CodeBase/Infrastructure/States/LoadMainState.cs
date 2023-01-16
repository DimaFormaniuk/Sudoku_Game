using CodeBase.Data;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.States
{
    public class LoadMainState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly ISaveLoadService _saveLoadService;

        public LoadMainState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IUIFactory uiFactory, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            _uiFactory.Cleanup();
            _sceneLoader.Load(Scenes.Main.GetDescription(), OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            InitUIRoot();
            InitMenu();
            InformProgressReaders();

            _gameStateMachine.Enter<SelectLevelState>();
        }

        private void InformProgressReaders()
        {
            _saveLoadService.InformProgressReaders();
        }

        private void InitUIRoot() =>
            _uiFactory.CreateUIRoot();

        private void InitMenu() =>
            _uiFactory.CreateMenu();
    }
}