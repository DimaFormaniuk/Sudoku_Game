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

        public void Init(UISelectLevelDifficulty uiSelectLevelDifficulty)
        {
            _uiSelectLevelDifficulty = uiSelectLevelDifficulty;
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            Index = playerProgress.LevelMenuData.LastSelectLevel;

            InitGrid(playerProgress);
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
        }

        private void Unsubscribe()
        {
            _uiCellButtons.ForEach(x => x.Click -= OnClickCell);
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

        private void InitGrid(PlayerProgress playerProgress)
        {
            for (int i = 0; i < Constants.LevelCount; i++)
            {
                int index = i + 1;
                bool data = playerProgress.LevelDatas.GetData(_uiSelectLevelDifficulty.DifficultyGame, index);
                UICellButton cell = Instantiate(_prefabCell, this.transform);
                cell.Init(index, data);
                _uiCellButtons.Add(cell);
            }
        }
    }
}