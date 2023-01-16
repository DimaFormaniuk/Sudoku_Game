namespace CodeBase.Infrastructure.States
{
    public class SelectLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public SelectLevelState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
        }
    }
}