using Data;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SudokuGame
{
    public class ButtonRestartGame : MonoBehaviour
    {
        [SerializeField] private Button button;

        private IGameStateMachine _stateMachine;
        private IPersistentProgressService _progressService;

        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();
            _progressService = AllServices.Container.Single<IPersistentProgressService>();
        }

        private void OnEnable()
        {
            button.onClick.AddListener(OnClickMenu);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(OnClickMenu);
        }

        private void OnClickMenu()
        {
            _progressService.Progress.LevelMenuData.DifficultyGame = _progressService.Progress.LastGameData.DifficultyGame;
            _progressService.Progress.LevelMenuData.LastSelectLevel = _progressService.Progress.LastGameData.IndexLevel;

            _progressService.Progress.LastGameData = new LastGameData();
            
            _stateMachine.Enter<NewGameState>();
        }
    }
}