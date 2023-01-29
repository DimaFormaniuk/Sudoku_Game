using System;
using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.UI.Menu
{
    public class UISelectLevelGrid : MonoBehaviour, ISavedProgress
    {
        public int Index { get; private set; }
        public event Action UpdateIndex;

        [SerializeField] private UICellButton _prefabCell;
        [SerializeField] private Transform _selector;

        private List<UICellButton> _uiCellButtons = new List<UICellButton>();
        private UISelectLevelDifficulty _uiSelectLevelDifficulty;
        private PlayerProgress _playerProgress;

        public void Init(UISelectLevelDifficulty uiSelectLevelDifficulty)
        {
            _uiSelectLevelDifficulty = uiSelectLevelDifficulty;
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            _playerProgress = playerProgress;
            Index = playerProgress.LevelMenuData.LastSelectLevel;

            InitGrid();
            Subscribe();
            RefreshSelector();
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.LevelMenuData.LastSelectLevel = Index;
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _uiCellButtons.ForEach(x => x.Click += OnClickCell);
            _uiSelectLevelDifficulty.UpdateDifficulty += OnUpdateDifficulty;
        }

        private void Unsubscribe()
        {
            _uiCellButtons.ForEach(x => x.Click -= OnClickCell);
            _uiSelectLevelDifficulty.UpdateDifficulty -= OnUpdateDifficulty;
        }

        private void RefreshSelector()
        {
            RefreshSelector(_uiCellButtons.Find(x => x.Index == Index).transform);
        }

        private void RefreshSelector(Transform transform)
        {
            _selector.transform.SetParent(transform, false);
            _selector.transform.SetAsFirstSibling();
        }

        private void OnClickCell(UICellButton uiCellButton)
        {
            Index = uiCellButton.Index;
            UpdateIndex?.Invoke();

            RefreshSelector(uiCellButton.transform);
        }

        private void InitGrid()
        {
            for (int i = 0; i < Constants.LevelCount; i++)
            {
                int index = i + 1;
                var saveLevel = GetSaveLevel(index);
                var completedLevel = GetCompletedLevel(index);

                UICellButton cell = Instantiate(_prefabCell, this.transform);
                cell.Init(index, completedLevel, saveLevel);
                _uiCellButtons.Add(cell);
            }
        }

        private void OnUpdateDifficulty()
        {
            RefreshGrind();
        }

        private void RefreshGrind()
        {
            foreach (var uiCellButton in _uiCellButtons)
            {
                var saveLevel = GetSaveLevel(uiCellButton.Index);
                var completedLevel = GetCompletedLevel(uiCellButton.Index);

                uiCellButton.SetCompleted(completedLevel);
                uiCellButton.SetSaveLevel(saveLevel);
            }
        }

        private bool GetCompletedLevel(int index)
        {
            return _playerProgress.LevelDatas
                .GetCompletedLevel(_uiSelectLevelDifficulty.DifficultyGame, index);
        }

        private bool GetSaveLevel(int index)
        {
            return _playerProgress.LastGameData.IndexLevel == index && _playerProgress.LastGameData.DifficultyGame ==
                _uiSelectLevelDifficulty.DifficultyGame;
        }
    }
}