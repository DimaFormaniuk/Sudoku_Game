using Infrastructure.Services;
using Infrastructure.Services.Ads;
using Infrastructure.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public class UIContinueButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _informationText;

        private DifficultyGame _difficulty;
        private int _indexLevel;

        private IGameStateMachine _stateMachine;
        private IAdsService _adsService;

        private void Awake()
        {
            AllServices services = AllServices.Container;
            
            _stateMachine = services.Single<IGameStateMachine>();
            _adsService = services.Single<IAdsService>();
        }

        public void RefreshUI(DifficultyGame difficultyGame, int index)
        {
            _difficulty = difficultyGame;
            _indexLevel = index;
        
            RefreshUI();
        }

        private void RefreshUI()
        {
            _informationText.text = $"{_difficulty} {_indexLevel}";
        }
    
        private void OnEnable()
        {
            _button.onClick.AddListener(OnClickContinueGame);
        }
    
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClickContinueGame);
        }

        private void OnClickContinueGame()
        {
            if (_adsService.HasLoadedInterstitial())
                _adsService.ShowInterstitial();
            
            _stateMachine.Enter<ContinueGameState>();
        }
    }
}
