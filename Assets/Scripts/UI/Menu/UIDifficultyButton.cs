using System;
using Data;
using Infrastructure.Services;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.Theme;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    [RequireComponent(typeof(Button))]
    public class UIDifficultyButton : MonoBehaviour, ISavedProgressReader
    {
        public DifficultyGame DifficultyType => _difficultyType;
        public event Action<UIDifficultyButton> Click;

        [SerializeField] private DifficultyGame _difficultyType;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _difficultyTypeText;
        [SerializeField] private TMP_Text _informationText;

        private MainThemeConfigData _themeConfigs;
        private PlayerProgress _playerProgress;
        private bool _select;

        private void Awake()
        {
            _themeConfigs = AllServices.Container.Single<IThemeService>().MainThemeConfigs;
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            _playerProgress = playerProgress;

            Refresh();
        }

        public void Select()
        {
            _select = true;

            RefreshColor();
        }
        
        public void Unselect()
        {
            _select = false;

            RefreshColor();
        }

        private void Refresh()
        {
            int count = _playerProgress.LevelDatas.DifficultyLevelData.GetLevelData(_difficultyType).CompletedLevel
                .Count;

            if (count > 0)
            {
                _informationText.gameObject.SetActive(true);
                _informationText.text = $"{count}/{Constants.LevelCount}";
            }
            else
            {
                _informationText.gameObject.SetActive(false);
            }

            RefreshColor();
        }

        private void RefreshColor()
        {
            if (_select)
                _difficultyTypeText.color = _themeConfigs.SelectDifficultyColor;
            else
                _difficultyTypeText.color = _themeConfigs.BaseDifficultyColor;
        }

        private void OnEnable() =>
            _button.onClick.AddListener(ClickCell);

        private void OnDisable() =>
            _button.onClick.RemoveListener(ClickCell);

        private void ClickCell() =>
            Click?.Invoke(this);
    }
}