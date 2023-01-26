using CodeBase.UI.Services.Theme;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.SudokuGame.Input
{
    public class UIFunctionalButton : MonoBehaviour, IThemeReader
    {
        [Header("Clear")] 
        [SerializeField] private Button _clear;
        [SerializeField] private Image _iconClear;
        [SerializeField] private TMP_Text _clearText;
        [SerializeField] private Animation _animationClear;
        
        [Header("Hint")] 
        [SerializeField] private Button _hint;
        [SerializeField] private Image _iconHint;
        [SerializeField] private TMP_Text _hintText;
        [SerializeField] private Animation _animationHint;
        
        [Header("Auto Hints")] 
        [SerializeField] private Button _autoHint;
        [SerializeField] private Image _iconAutoHint;
        [SerializeField] private TMP_Text _autoHintText;
        [SerializeField] private Animation _animationAutoHint;

        private IFunctionalButtonsListener _functionalButtonsListener;
        private ThemeConfigData _themeConfigData;

        private bool _inputNumber = true;
        
        public void Init(IFunctionalButtonsListener functionalButtonsListener)
        {
            _functionalButtonsListener = functionalButtonsListener;
        }

        public void UpdateTheme(ThemeConfigData themeConfigData)
        {
            _themeConfigData = themeConfigData;

            Refresh();
        }

        private void OnEnable()
        {
            _clear.onClick.AddListener(OnClickClear);
            _hint.onClick.AddListener(OnClickHint);
            _autoHint.onClick.AddListener(OnClickAutoHint);
        }

        private void OnDisable()
        {
            _clear.onClick.RemoveListener(OnClickClear);
            _hint.onClick.RemoveListener(OnClickHint);
            _autoHint.onClick.RemoveListener(OnClickAutoHint);
        }

        private void OnClickClear()
        {
            _functionalButtonsListener.ClickClear();

            _animationClear.Play();
            Refresh();
        }

        private void OnClickHint()
        {
            _inputNumber = !_inputNumber;
            
            _functionalButtonsListener.ClickHints();

            _animationHint.Play();
            Refresh();
        }

        private void OnClickAutoHint()
        {
            _functionalButtonsListener.AutoHints();

            _animationAutoHint.Play();
            Refresh();
        }
        
        private void Refresh()
        {
            Color color = _themeConfigData.InputLeftTextColor;

            _iconClear.color = color;
            _clearText.color = color;

            _iconHint.color = color;
            _hintText.color = color;

            _iconAutoHint.color = color;
            _autoHintText.color = color;

            if (_inputNumber == false)
            {
                color = _themeConfigData.SelectorColor;
                
                _iconHint.color = color;
                _hintText.color = color;
            }
        }
    }
}