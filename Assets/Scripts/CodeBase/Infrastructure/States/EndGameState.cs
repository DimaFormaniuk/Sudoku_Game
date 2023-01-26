using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.States
{
    public class EndGameState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IUIFactoryService _iuiFactoryService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IPersistentProgressService _progressService;

        public EndGameState(GameStateMachine stateMachine,IUIFactoryService iuiFactoryService, ISaveLoadService saveLoadService, IPersistentProgressService progressService)
        {
            _stateMachine = stateMachine;
            _iuiFactoryService = iuiFactoryService;
            _saveLoadService = saveLoadService;
            _progressService = progressService;
        }

        public void Enter()
        {
            _iuiFactoryService.Cleanup();
            _iuiFactoryService.ClearRoot();
            _iuiFactoryService.CreateEndGame();

            _saveLoadService.InformProgressReaders();
            
            _progressService.Progress.LevelDatas.CompleteLastGame(_progressService.Progress.LastGameData);
            _progressService.Progress.LastGameData = new LastGameData();
            
            _saveLoadService.SaveProgress();
        }

        public void Exit()
        {
        }
    }
}