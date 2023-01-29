using System;
using CodeBase.Infrastructure.Services;
using CodeBase.UI.Services.Theme;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Menu
{
    [RequireComponent(typeof(Button))]
    public class UICellButton : MonoBehaviour
    {
        public event Action<UICellButton> Click;
        public int Index { get; private set; }

        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;

        private MainThemeConfigData _themeConfigs;

        private bool _completed;
        private bool _saveLevel;

        private void Awake()
        {
            _themeConfigs = AllServices.Container.Single<IThemeService>().MainThemeConfigs;
        }

        public void Init(int index, bool completed, bool saveLevel)
        {
            Index = index;
            _completed = completed;
            _saveLevel = saveLevel;

            Refresh();
        }

        public void SetCompleted(bool completed)
        {
            _completed = completed;

            Refresh();
        }

        public void SetSaveLevel(bool saveLevel)
        {
            _saveLevel = saveLevel;

            Refresh();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(ClickCell);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ClickCell);
        }

        private void ClickCell() =>
            Click?.Invoke(this);

        private void Refresh()
        {
            _text.text = Index.ToString();

            RefreshColor();
        }

        private void RefreshColor()
        {
            _text.color = _themeConfigs.BaseLevelColor;

            if (_completed)
                _text.color = _themeConfigs.CompletedLevelColor;

            if (_saveLevel)
                _text.color = _themeConfigs.SavedLevelColor;
        }
    }
}