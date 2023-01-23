using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.States
{
    public class EndGameState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IPersistentProgressService _progressService;

        public EndGameState(GameStateMachine stateMachine,IUIFactory uiFactory, ISaveLoadService saveLoadService, IPersistentProgressService progressService)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _saveLoadService = saveLoadService;
            _progressService = progressService;
        }

        public void Enter()
        {
            _uiFactory.Cleanup();
            _uiFactory.ClearRoot();
            _uiFactory.CreateEndGame();

            _saveLoadService.InformProgressReaders();
            
            _progressService.Progress.LevelDatas.CompleteLastGame(_progressService.Progress.LastGameData);
            _progressService.Progress.LastGameData = new LastGameData();
        }

        public void Exit()
        {
        }
    }
}