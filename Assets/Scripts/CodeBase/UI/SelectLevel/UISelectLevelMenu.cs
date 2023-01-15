using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.UI.SelectLevel
{
    public class UISelectLevelMenu : MonoBehaviour, ISavedProgress
    {
        public DifficultyGame DifficultyGame { get; private set; } = DifficultyGame.Easy;

        [SerializeField] private Transform _selector;
        [SerializeField] private List<UIMenuButton> _uiMenuButtons;

        public void LoadProgress(PlayerProgress playerProgress)
        {
            DifficultyGame = playerProgress.DifficultyGame;

            RefreshSelector();
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.DifficultyGame = DifficultyGame;
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

        private void RefreshSelector()
        {
            RefreshSelector(_uiMenuButtons.Find(x => x.DifficultyType == DifficultyGame).transform);
        }

        private void RefreshSelector(Transform transform)
        {
            _selector.position = transform.position;
        }
    }
}