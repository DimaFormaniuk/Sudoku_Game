using CodeBase.Data;
using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.States
{
    public class LoadMainState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactoryService _iuiFactoryService;

        public LoadMainState(GameStateMachine gameStateMachine, SceneLoader sceneLoader,IUIFactoryService iuiFactoryService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _iuiFactoryService = iuiFactoryService;
        }

        public void Enter()
        {
            _sceneLoader.Load(Scenes.Main.GetDescription(), OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            _iuiFactoryService.CreateUIRoot();

            _gameStateMachine.Enter<SelectLevelState>();
        }
    }
}