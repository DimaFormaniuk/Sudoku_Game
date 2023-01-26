using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.SudokuGame.Input
{
    public class UIInput : MonoBehaviour, IUIInput, IFunctionalButtonsListener
    {
        [SerializeField] private UIFunctionalButton _uiFunctionalButton;
        [SerializeField] private List<UIButtonNumber> _uiButtonNumbers;

        private IInputListener _inputListener;

        private bool _inputNumber = true;

        public void Init(IInputListener inputListener)
        {
            _inputListener = inputListener;

            _uiFunctionalButton.Init(this);

            InitButtons();
            Subscrible();
        }

        public void RefreshLeftNumber(int number, int count)
        {
            UIButtonNumber tmp = _uiButtonNumbers.Find(x => x.Number == number);
            tmp.RefreshLeftNumber(count);
            tmp.gameObject.SetActive(count != 0);
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

        public void ClickClear()
        {
            _inputListener.ClickClear();
        }

        public void ClickHints()
        {
            _inputNumber = !_inputNumber;

            if (_inputNumber == false)
                _inputListener.RefreshInputHints();

            if (_inputNumber)
                RefreshInputsNumber();
        }

        public void AutoHints()
        {
            _inputListener.AutoHints();
        }
    }
}