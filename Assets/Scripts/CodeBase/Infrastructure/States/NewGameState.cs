using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Theme;
using CodeBase.UI.SudokuGame;

namespace CodeBase.Infrastructure.States
{
    public class NewGameState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IUIFactoryService _iuiFactoryService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IThemeService _themeService;

        public NewGameState(GameStateMachine gameStateMachine, IUIFactoryService iuiFactoryService, ISaveLoadService saveLoadService, IThemeService themeService)
        {
            _themeService = themeService;
            _saveLoadService = saveLoadService;
            _gameStateMachine = gameStateMachine;
            _iuiFactoryService = iuiFactoryService;
        }

        public void Enter()
        {
            _iuiFactoryService.Cleanup();
            _iuiFactoryService.ClearRoot();
            var game = _iuiFactoryService.CreateNewGame();
            
            _saveLoadService.InformProgressReaders();
            _themeService.InfomThemeListeners();

            game.GetComponent<SudokuGame>().NewGame();
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
        }
    }
}