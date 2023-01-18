using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Theme;
using CodeBase.UI.SudokuGame;

namespace CodeBase.Infrastructure.States
{
    public class NewGameState : IState
    {
        private GameStateMachine _gameStateMachine;
        private IUIFactory _uiFactory;
        private ISaveLoadService _saveLoadService;
        private IThemeService _themeService;

        public NewGameState(GameStateMachine gameStateMachine, IUIFactory uiFactory, ISaveLoadService saveLoadService, IThemeService themeService)
        {
            _themeService = themeService;
            _saveLoadService = saveLoadService;
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            _uiFactory.Cleanup();
            _uiFactory.ClearRoot();
            var game = _uiFactory.CreateNewGame();
            
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