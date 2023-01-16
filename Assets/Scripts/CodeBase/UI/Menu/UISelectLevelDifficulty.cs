using System;
using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.UI.Menu
{
    public class UISelectLevelDifficulty : MonoBehaviour, ISavedProgress
    {
        public DifficultyGame DifficultyGame { get; private set; } = DifficultyGame.Easy;
        public event Action UpdateDifficulty;

        [SerializeField] private Transform _selector;
        [SerializeField] private List<UIDifficultyButton> _uiDifficultyButtons;

        public void LoadProgress(PlayerProgress playerProgress)
        {
            DifficultyGame = playerProgress.LevelMenuData.DifficultyGame;

            RefreshSelector();
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.LevelMenuData.DifficultyGame = DifficultyGame;
        }

        private void OnEnable()
        {
            _uiDifficultyButtons.ForEach(x => x.Click += OnClickMenuButton);
        }

        private void OnDisable()
        {
            _uiDifficultyButtons.ForEach(x => x.Click -= OnClickMenuButton);
        }

        private void OnClickMenuButton(UIDifficultyButton uiDifficultyButton)
        {
            DifficultyGame = uiDifficultyButton.DifficultyType;
            UpdateDifficulty?.Invoke();

            RefreshSelector(uiDifficultyButton.transform);
        }

        private void RefreshSelector()
        {
            RefreshSelector(_uiDifficultyButtons.Find(x => x.DifficultyType == DifficultyGame).transform);
        }

        private void RefreshSelector(Transform transform)
        {
            _selector.transform.SetParent(transform,false);
            _selector.transform.SetAsFirstSibling();
        }
    }
}