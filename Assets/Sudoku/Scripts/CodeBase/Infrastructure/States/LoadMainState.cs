using Sudoku.Scripts.CodeBase.Infrastructure.Factory;

namespace Sudoku.Scripts.CodeBase.Infrastructure.States
{
    public class LoadMainState : IPaylodedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;

        public LoadMainState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            _gameFactory.CreateMenu();

            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}