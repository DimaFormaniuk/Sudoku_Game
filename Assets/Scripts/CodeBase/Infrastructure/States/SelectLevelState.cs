using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.States
{
    public class SelectLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IUIFactoryService _iuiFactoryService;
        private readonly ISaveLoadService _saveLoadService;
        
        public SelectLevelState(GameStateMachine gameStateMachine, IUIFactoryService iuiFactoryService, ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _iuiFactoryService = iuiFactoryService;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _iuiFactoryService.Cleanup();
            _iuiFactoryService.ClearRoot();
            _iuiFactoryService.CreateMenu();

            _saveLoadService.InformProgressReaders();
        }

        public void Exit()
        {
        }
    }
}