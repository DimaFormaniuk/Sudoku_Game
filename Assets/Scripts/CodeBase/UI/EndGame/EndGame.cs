using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.EndGame
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private Button menuButton;
    
        private IGameStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();
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
            _stateMachine.Enter<SelectLevelState>();
        }
    }
}
