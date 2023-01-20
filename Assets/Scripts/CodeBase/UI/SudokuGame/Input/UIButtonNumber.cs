using System;
using CodeBase.UI.Services.Theme;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.SudokuGame.Input
{
    public class UIButtonNumber : MonoBehaviour,IThemeReader
    {
        [SerializeField] private Button _button;

        [SerializeField] private TMP_Text _numberText;
        [SerializeField] private TMP_Text _leftCountText;
        [SerializeField] private Image _background;

        public int Number { get; private set; }
        private int _leftNumber;
        private ThemeConfigs _themeConfigs;

        public event Action<int> ClickNumber;

        public void Init(int number)
        {
            Number = number;
            _leftNumber = 0;

            _numberText.text = $"{Number}";

            RefreshUI();
        }

        public void RefreshLeftNumber(int count)
        {
            _leftNumber = count;
            RefreshUI();
        }

        private void RefreshUI()
        {
            _leftCountText.text = $"{_leftNumber}";
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            ClickNumber?.Invoke(Number);
        }

        public void RefreshHint(bool contains)
        {
            if (contains)
            {
                _numberText.color = _themeConfigs.EnableHintTextColor;
                _leftCountText.color = _themeConfigs.EnableHintTextColor;
                _background.color = _themeConfigs.EnableHintBackgroundColor;
            }
            else
            {
                _numberText.color = _themeConfigs.DisableHintTextColor;
                _leftCountText.color = _themeConfigs.DisableHintTextColor;
                _background.color = _themeConfigs.DisableHintBackgroundColor;
            }
        }

        public void RefreshInput()
        {
            _numberText.color = _themeConfigs.InputTextColor;
            _leftCountText.color = _themeConfigs.InputLeftTextColor;
            _background.color = _themeConfigs.InputBackgroundColor;
        }

        public void UpdateTheme(ThemeConfigs themeConfigs)
        {
            _themeConfigs = themeConfigs;
        }
    }
}