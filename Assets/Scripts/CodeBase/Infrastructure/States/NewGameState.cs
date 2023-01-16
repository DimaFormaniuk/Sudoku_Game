using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.States
{
    public class NewGameState : IState
    {
        private GameStateMachine _gameStateMachine;
        private IUIFactory _uiFactory;

        public NewGameState(GameStateMachine gameStateMachine, IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
        }

        public void Exit()
        {
            _uiFactory.Cleanup();
            _uiFactory.ClearRoot();
            _uiFactory.CreateNewGame();

            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Enter()
        {
        }
    }
}