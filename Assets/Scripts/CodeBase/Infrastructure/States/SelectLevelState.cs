using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.States
{
    public class SelectLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly ISaveLoadService _saveLoadService;
        
        public SelectLevelState(GameStateMachine gameStateMachine, IUIFactory uiFactory, ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _uiFactory = uiFactory;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _uiFactory.Cleanup();
            _uiFactory.ClearRoot();
            _uiFactory.CreateMenu();

            _saveLoadService.InformProgressReaders();
        }

        public void Exit()
        {
        }
    }
}