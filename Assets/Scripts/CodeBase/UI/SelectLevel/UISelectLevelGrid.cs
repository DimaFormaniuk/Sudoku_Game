using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.UI.SelectLevel
{
    public class UISelectLevelGrid : MonoBehaviour, ISavedProgress
    {
        public int Index { get; private set; }

        [SerializeField] private Transform _selector;
        [SerializeField] private List<UICellButton> _uiCellButtons;

        //private IPersistentProgressService _progressService;
        private UISelectLevelMenu _uiSelectLevelMenu;

        public void Init(UISelectLevelMenu uiSelectLevelMenu)
        {
            _uiSelectLevelMenu = uiSelectLevelMenu;
        }

        // public void Init(IPersistentProgressService progressService, UISelectLevelMenu uiSelectLevelMenu)
        // {
        //     _uiSelectLevelMenu = uiSelectLevelMenu;
        //     _progressService = progressService;
        //
        //     LoadData();
        //     InitGrid();
        //     RefreshSelector();
        // }

        private void OnEnable()
        {
            _uiCellButtons.ForEach(x => x.Click += OnClickCell);
        }

        private void OnDisable()
        {
            _uiCellButtons.ForEach(x => x.Click -= OnClickCell);
        }

        // private void LoadData()
        // {
        //     Index = _progressService.PlayerProgress.LastSelectLevel;
        // }

        private void RefreshSelector()
        {
            RefreshSelector(_uiCellButtons.Find(x => x.Index == Index).transform);
        }

        private void RefreshSelector(Transform transform)
        {
            _selector.transform.position = transform.position;
        }

        private void OnClickCell(UICellButton uiCellButton)
        {
            Index = uiCellButton.Index;

            RefreshSelector(uiCellButton.transform);
        }

        private void InitGrid(PlayerProgress playerProgress)
        {
            for (int i = 0; i < _uiCellButtons.Count; i++)
            {
                int index = i + 1;
                bool data = playerProgress.LevelDatas.GetData(index, _uiSelectLevelMenu.DifficultyGame);
                _uiCellButtons[i].Init(index, data);
            }
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            Index = playerProgress.LastSelectLevel;

            InitGrid(playerProgress);
            RefreshSelector();
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.LastSelectLevel = Index;
        }
    }
}