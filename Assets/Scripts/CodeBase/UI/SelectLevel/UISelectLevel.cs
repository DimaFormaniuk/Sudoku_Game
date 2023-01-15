using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.SelectLevel
{
    public class UISelectLevel : MonoBehaviour
    {
        [SerializeField] private UISelectLevelMenu _uiSelectLevelMenu;
        [SerializeField] private UISelectLevelGrid _uiSelectLevelGrid;

        [SerializeField] private Button _continueLastGame;
        [SerializeField] private Button _startNewGame;

        //private IPersistentProgressService _progressService;

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            _uiSelectLevelGrid.Init(_uiSelectLevelMenu);
        }

        private void OnEnable()
        {
            var saveLoad = AllServices.Container.Single<ISaveLoadService>();

            _continueLastGame.onClick.AddListener(() => saveLoad.SaveProgress());
            _startNewGame.onClick.AddListener(() => saveLoad.InformProgressReaders());
        }
    }
}