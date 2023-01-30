using Infrastructure.Services;
using Infrastructure.Services.SaveLoad;
using Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SudokuGame
{
    public class ButtonToMain : MonoBehaviour
    {
        [SerializeField] private Button menuButton;
    
        private IGameStateMachine _stateMachine;
        private ISaveLoadService _saveLoadService;

        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        }

        private void OnEnable()
        {
            menuButton.onClick.AddListener(OnClickMenu);
        }
    
        private void OnDisable()
        {
            menuButton.onClick.RemoveListener(OnClickMenu);
        }
    
        private void OnClickMenu()
        {
            _saveLoadService.SaveProgress();
            
            _stateMachine.Enter<SelectLevelState>();
        }
    }
}
