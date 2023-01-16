using UnityEngine;

namespace CodeBase.UI.Menu
{
    public class UISelectLevel : MonoBehaviour
    {
        [SerializeField] private UISelectLevelDifficulty _uiSelectLevelDifficulty;
        [SerializeField] private UISelectLevelGrid _uiSelectLevelGrid;
        [SerializeField] private UIMenuButtons _uiMenuButtons;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _uiSelectLevelGrid.Init(_uiSelectLevelDifficulty);
            _uiMenuButtons.Init(_uiSelectLevelDifficulty, _uiSelectLevelGrid);
        }
    }
}