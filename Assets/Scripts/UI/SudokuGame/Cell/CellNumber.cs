using System;
using System.Collections.Generic;
using Infrastructure.Services.Theme;
using UI.SudokuGame.Hint;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SudokuGame.Cell
{
    public class CellNumber : MonoBehaviour
    {
        public int Number => _uiCellNumber.Number;
        public Vector2Int IndexCellVector { get; private set; }
        public int IndexBlock { get; private set; }
        public bool LevelNumber => _uiCellNumber.LevelNumber;
        public bool CorrectNumber => _uiCellNumber.CorrectNumber;

        public event Action<CellNumber> ClickCell;

        [SerializeField] private UICellBackgroundNumber _uiCellBackgroundNumber;
        [SerializeField] private UICellNumber _uiCellNumber;
        [SerializeField] private UIHints _uiHints;
        [SerializeField] private Button _button;

        private ThemeConfigData _themeConfigData;

        public void Init(int number, Vector2Int indexCellVector, int indexBlock)
        {
            IndexBlock = indexBlock;
            IndexCellVector = indexCellVector;

            _uiCellNumber.Init(number);
            _uiCellBackgroundNumber.Init();
            _uiHints.Init(LevelNumber);
            _uiHints.ClearHints();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        public void SetUserNumber(int number)
        {
            _uiCellNumber.SetUserNumber(number);
            _uiHints.ClearHints();
        }

        public void CellCorrectNumber()
        {
            _uiCellNumber.CellCorrectNumber();
        }

        public void ClearNumber()
        {
            _uiCellNumber.ClearNumber();
        }

        public void Unselect()
        {
            _uiCellBackgroundNumber.Unselect();
        }

        public void Select()
        {
            _uiCellBackgroundNumber.Select();
        }

        public void SelectorLine()
        {
            _uiCellBackgroundNumber.SelectorLine();
        }

        public void Error()
        {
            _uiCellNumber.Error();
        }

        public void DeniesNumber()
        {
            _uiCellBackgroundNumber.DeniesNumber();
        }

        public void SetHints(List<int> hints)
        {
            _uiHints.SetHints(hints);
        }

        public void SetUserHint(int number)
        {
            _uiHints.SetUserHint(number);
        }

        public void ClearHints()
        {
            _uiHints.ClearHints();
        }

        public void ShowDeniesForHints()
        {
            _uiHints.ShowDeniesForHints();
        }

        public List<int> GetHints() => _uiHints.GetHints();

        private void OnClick()
        {
            ClickCell?.Invoke(this);
        }

        public void CompleteBlockOrLine()
        {
            _uiCellNumber.CompleteBlockOrLine();
        }

        public void ErrorInput()
        {
            _uiCellNumber.ErrorInput();
        }
    }
}