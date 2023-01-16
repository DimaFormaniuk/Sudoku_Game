using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.SudokuGame
{
    public class UICellNumber : MonoBehaviour
    {
        public int Number { get; private set; }
        public int IndexCell { get; private set; }

        public event Action<UICellNumber> ClickCell;

        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _numberText;
        [SerializeField] private Image _background;
        [SerializeField] private UIHints _uiHints;

        private bool _looked;

        public void Init(int number, int indexCell)
        {
            Number = number;
            IndexCell = indexCell;

            _looked = Number != 0;

            RefreshUI();

            _uiHints.Init();
            _uiHints.HideAll();
        }

        public void SetUserNumber(int number)
        {
            if (_looked)
                return;
            
            Number = number;
            RefreshUI();
        }

        private void RefreshUI()
        {
            _numberText.text = $"{Number}";
            _numberText.gameObject.SetActive(Number != 0);
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
            ClickCell?.Invoke(this);
            Debug.LogError($"{Number} {IndexCell}");
        }
    }
}