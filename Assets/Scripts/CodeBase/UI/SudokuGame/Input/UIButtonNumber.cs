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
        private ThemeConfigData _themeConfigData;

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
                _numberText.color = _themeConfigData.EnableHintTextColor;
                _leftCountText.color = _themeConfigData.EnableHintTextColor;
                _background.color = _themeConfigData.EnableHintBackgroundColor;
            }
            else
            {
                _numberText.color = _themeConfigData.DisableHintTextColor;
                _leftCountText.color = _themeConfigData.DisableHintTextColor;
                _background.color = _themeConfigData.DisableHintBackgroundColor;
            }
        }

        public void RefreshInput()
        {
            _numberText.color = _themeConfigData.InputTextColor;
            _leftCountText.color = _themeConfigData.InputLeftTextColor;
            _background.color = _themeConfigData.InputBackgroundColor;
        }

        public void UpdateTheme(ThemeConfigData themeConfigData)
        {
            _themeConfigData = themeConfigData;
        }
    }
}