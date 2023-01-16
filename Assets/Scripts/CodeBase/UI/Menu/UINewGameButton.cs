using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Menu
{
    public class UINewGameButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _informationText;

        private DifficultyGame _difficulty;
        private int _indexLevel;

        private ISaveLoadService _saveLoad;
        private IGameStateMachine _stateMachine;

        private void Awake()
        {
            _saveLoad = AllServices.Container.Single<ISaveLoadService>();
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();
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
            _button.onClick.AddListener(OnClickNewGame);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClickNewGame);
        }

        private void OnClickNewGame()
        {
            _saveLoad.SaveProgress();
            _stateMachine.Enter<NewGameState>();
        }
    }
}