using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Theme;
using CodeBase.UI.SudokuGame;

namespace CodeBase.Infrastructure.States
{
    public class ContinueGameState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IUIFactory _uiFactory;
        private ISaveLoadService _saveLoadService;
        private IThemeService _themeService;

        public ContinueGameState(GameStateMachine gameStateMachine, IUIFactory uiFactory, ISaveLoadService saveLoadService, IThemeService themeService)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _saveLoadService = saveLoadService;
            _themeService = themeService;
        }

        public void Enter()
        {
            _uiFactory.Cleanup();
            _uiFactory.ClearRoot();
            var game = _uiFactory.CreateContinueGame();

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