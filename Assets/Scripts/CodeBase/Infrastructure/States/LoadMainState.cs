using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.States
{
    public class LoadMainState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly IPersistentProgressService _progressService;

        public LoadMainState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IUIFactory uiFactory,
            IPersistentProgressService progressService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _progressService = progressService;
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

            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitUIRoot() =>
            _uiFactory.CreateUIRoot();

        private void InitMenu() =>
            _uiFactory.CreateMenu();

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _uiFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.PlayerProgress);
        }
    }
}