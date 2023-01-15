using System.Collections.Generic;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.UI.SelectLevel
{
    public class UISelectLevelGrid : MonoBehaviour
    {
        public int Index { get; private set; }

        [SerializeField] private Transform _selector;
        [SerializeField] private List<UICellButton> _uiCellButtons;

        private IPersistentProgressService _progressService;
        private UISelectLevelMenu _uiSelectLevelMenu;


        public void Init(IPersistentProgressService progressService, UISelectLevelMenu uiSelectLevelMenu)
        {
            _uiSelectLevelMenu = uiSelectLevelMenu;
            _progressService = progressService;

            RefreshGrid();
        }

        private void OnEnable()
        {
            _uiCellButtons.ForEach(x => x.Click += OnClickCell);
        }

        private void OnDisable()
        {
            _uiCellButtons.ForEach(x => x.Click -= OnClickCell);
        }

        private void OnClickCell(UICellButton uiCellButton)
        {
            Index = uiCellButton.Index;

            _selector.transform.position = uiCellButton.transform.position;
        }

        private void RefreshGrid()
        {
            int count = _uiCellButtons.Count;
            int index;
        
            for (int i = 0; i < count; i++)
            {
                index = i + 1;
                UICellButton cellButton = _uiCellButtons[i];
//            var data = _progressService.PlayerProgress.LevelDatas.GetData(index, _uiSelectLevelMenu.DifficultyGame);

                cellButton.Init(index, false);
            }
        }
    }
}