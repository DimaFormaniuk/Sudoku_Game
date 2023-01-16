using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.States
{
    public class ContinueGameState : IState
    {
        private GameStateMachine _gameStateMachine;
        private IUIFactory _uiFactory;

        public ContinueGameState(GameStateMachine gameStateMachine, IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
        }
        
        public void Exit()
        {
            _uiFactory.Cleanup();
            _uiFactory.ClearRoot();
            _uiFactory.CreateContinueGame();
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Enter()
        {
            
        }
    }
}