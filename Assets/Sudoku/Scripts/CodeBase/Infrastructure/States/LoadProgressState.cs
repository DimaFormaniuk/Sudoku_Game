using Sudoku.Scripts.CodeBase.Data;
using Sudoku.Scripts.CodeBase.Infrastructure.Services.PersistentProgress;
using Sudoku.Scripts.CodeBase.Infrastructure.Services.SaveLoad;

namespace Sudoku.Scripts.CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine stateMachine, IPersistentProgressService progressService,
            ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _stateMachine.Enter<LoadMainState, string>("Main");
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.PlayerProgress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            return new PlayerProgress();
        }
    }
}