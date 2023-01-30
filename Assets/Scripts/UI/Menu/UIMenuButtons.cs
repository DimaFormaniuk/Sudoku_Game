using Data;
using Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace UI.Menu
{
    public class UIMenuButtons : MonoBehaviour, ISavedProgressReader
    {
        [SerializeField] private UIContinueButton _continueButton;
        [SerializeField] private UINewGameButton _newGameButton;
    
        private UISelectLevelDifficulty _uiSelectLevelDifficulty;
        private UISelectLevelGrid _uiSelectLevelGrid;

        public void Init(UISelectLevelDifficulty uiSelectLevelDifficulty, UISelectLevelGrid uiSelectLevelGrid)
        {
            _uiSelectLevelGrid = uiSelectLevelGrid;
            _uiSelectLevelDifficulty = uiSelectLevelDifficulty;
        
            Subscribe();
        }
    
        public void LoadProgress(PlayerProgress playerProgress)
        {
            InitContinueButton(playerProgress);
            InitNewGameButton(playerProgress);
        }

        private void InitNewGameButton(PlayerProgress playerProgress)
        {
            _newGameButton.RefreshUI(playerProgress.LevelMenuData.DifficultyGame, playerProgress.LevelMenuData.LastSelectLevel);
        }

        private void InitContinueButton(PlayerProgress playerProgress)
        {
            _continueButton.gameObject.SetActive(playerProgress.LastGameData.IndexLevel != 0);
            _continueButton.RefreshUI(playerProgress.LastGameData.DifficultyGame, playerProgress.LastGameData.IndexLevel);
        }

        private void Subscribe()
        {
            _uiSelectLevelGrid.UpdateIndex += RefreshUI;
            _uiSelectLevelDifficulty.UpdateDifficulty += RefreshUI;
        }

        private void Unsubscrible()
        {
            _uiSelectLevelGrid.UpdateIndex -= RefreshUI;
            _uiSelectLevelDifficulty.UpdateDifficulty -= RefreshUI;
        }

        private void RefreshUI()
        {
            _newGameButton.RefreshUI(_uiSelectLevelDifficulty.DifficultyGame, _uiSelectLevelGrid.Index);
        }

        private void OnDestroy()
        {
            Unsubscrible();
        }
    }
}