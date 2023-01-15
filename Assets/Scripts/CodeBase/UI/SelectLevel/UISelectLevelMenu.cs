using System.Collections.Generic;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.UI.SelectLevel
{
    public class UISelectLevelMenu : MonoBehaviour
    {
        private IPersistentProgressService _progressService;
        public DifficultyGame DifficultyGame { get; private set; } = DifficultyGame.Easy;

        [SerializeField] private Transform _selector;
        [SerializeField] private List<UIMenuButton> _uiMenuButtons;

        public void Init(IPersistentProgressService progressService)
        {
            _progressService = progressService;
        }

        private void OnEnable()
        {
            _uiMenuButtons.ForEach(x => x.Click += OnClickMenuButton);
        }

        private void OnDisable()
        {
            _uiMenuButtons.ForEach(x => x.Click -= OnClickMenuButton);
        }

        private void OnClickMenuButton(UIMenuButton uiMenuButton)
        {
            DifficultyGame = uiMenuButton.DifficultyType;

            RefreshSelector(uiMenuButton.transform);
        }

        private void RefreshSelector(Transform transform)
        {
            _selector.position = transform.position;
        }
    }
}