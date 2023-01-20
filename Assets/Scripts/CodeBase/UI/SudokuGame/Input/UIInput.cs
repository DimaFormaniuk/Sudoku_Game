using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.SudokuGame.Input
{
    public class UIInput : MonoBehaviour, IUIInput
    {
        [SerializeField] private List<UIButtonNumber> _uiButtonNumbers;

        [SerializeField] private Button _clear;
        [SerializeField] private Button _hint;
        [SerializeField] private Button _autoHint;

        private IUIInputListener _inputListener;

        private bool _inputNumber = true;

        public void Init(IUIInputListener inputListener)
        {
            _inputListener = inputListener;

            InitButtons();
            Subscrible();
        }

        public void RefreshLeftNumber(int number, int count)
        {
            _uiButtonNumbers.Find(x => x.Number == number).RefreshLeftNumber(count);
        }

        public void HintsInCell(List<int> numbers)
        {
            if (_inputNumber)
            {
                RefreshInputsNumber();

                return;
            }

            RefreshInputNumberHints(numbers);
        }

        private void RefreshInputNumberHints(List<int> numbers)
        {
            foreach (UIButtonNumber uiButtonNumber in _uiButtonNumbers)
                uiButtonNumber.RefreshHint(numbers.Contains(uiButtonNumber.Number));
        }

        private void RefreshInputsNumber()
        {
            foreach (UIButtonNumber uiButtonNumber in _uiButtonNumbers)
                uiButtonNumber.RefreshInput();
        }

        private void OnDestroy()
        {
            Unsubscrible();
        }

        private void InitButtons()
        {
            for (var i = 0; i < _uiButtonNumbers.Count; i++)
                _uiButtonNumbers[i].Init(i + 1);

            _clear.onClick.AddListener(OnClickClear);
            _hint.onClick.AddListener(OnClickHint);
            _autoHint.onClick.AddListener(OnClickAutoHint);
        }

        private void OnClickClear()
        {
            _inputListener.ClickClear();
        }

        private void OnClickHint()
        {
            _inputNumber = !_inputNumber;

            if (_inputNumber == false)
                _inputListener.RefreshInputHints();

            if (_inputNumber)
                RefreshInputsNumber();
        }

        private void OnClickAutoHint()
        {
        }

        private void Subscrible()
        {
            for (var i = 0; i < _uiButtonNumbers.Count; i++)
                _uiButtonNumbers[i].ClickNumber += OnClickNumber;
        }

        private void Unsubscrible()
        {
            for (var i = 0; i < _uiButtonNumbers.Count; i++)
                _uiButtonNumbers[i].ClickNumber -= OnClickNumber;
        }

        private void OnClickNumber(int number)
        {
            if (_inputNumber)
                _inputListener.InputNumber(number);
            else
                _inputListener.InputHint(number);
        }
    }
}