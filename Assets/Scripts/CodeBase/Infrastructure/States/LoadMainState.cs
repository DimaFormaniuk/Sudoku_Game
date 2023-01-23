using CodeBase.Data;
using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.States
{
    public class LoadMainState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;

        public LoadMainState(GameStateMachine gameStateMachine, SceneLoader sceneLoader,IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
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
            _uiFactory.CreateUIRoot();
            
            _gameStateMachine.Enter<SelectLevelState>();
        }
    }
}