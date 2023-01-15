using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.UI.SelectLevel
{
    public class UISelectLevel : MonoBehaviour
    {
        [SerializeField] private UISelectLevelMenu _uiSelectLevelMenu;
        [SerializeField] private UISelectLevelGrid _uiSelectLevelGrid;

        private IPersistentProgressService _progressService;
        
        public void Init(IPersistentProgressService progressService)
        {
            _progressService = progressService;
            //_progressService = AllServices.Container.Single<IPersistentProgressService>();
        }
        
        private void Awake()
        {
            _progressService = AllServices.Container.Single<IPersistentProgressService>();
            
            _uiSelectLevelMenu.Init(_progressService);
            _uiSelectLevelGrid.Init(_progressService, _uiSelectLevelMenu);
        }
    }
}
