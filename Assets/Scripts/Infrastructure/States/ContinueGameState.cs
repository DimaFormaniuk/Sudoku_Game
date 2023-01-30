using Infrastructure.Services.Factory;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.Theme;
using UI.SudokuGame;

namespace Infrastructure.States
{
    public class ContinueGameState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IUIFactoryService _iuiFactoryService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IThemeService _themeService;

        public ContinueGameState(GameStateMachine gameStateMachine, IUIFactoryService iuiFactoryService, ISaveLoadService saveLoadService, IThemeService themeService)
        {
            _gameStateMachine = gameStateMachine;
            _iuiFactoryService = iuiFactoryService;
            _saveLoadService = saveLoadService;
            _themeService = themeService;
        }

        public void Enter()
        {
            _iuiFactoryService.Cleanup();
            _iuiFactoryService.ClearRoot();
            var game = _iuiFactoryService.CreateContinueGame();

            _saveLoadService.InformProgressReaders();
            _themeService.InfomThemeListeners();

            game.GetComponent<SudokuGame>().ContinueGame();

            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
        }
    }
}