using System;
using System.Collections.Generic;
using CodeBase.UI.Services.Theme;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.SudokuGame
{
    public class UICellNumber : MonoBehaviour, IThemeReader
    {
        public int Number { get; private set; }
        public int IndexCell { get; private set; }
        public Vector2Int IndexCellVector { get; private set; }
        public int IndexBlock { get; private set; }
        public CellStatus CellStatus => _cellStatus;
        public bool UserInputNumber => _userInputNumber;
        public bool LevelNumber => _looked;
        public bool CorrectNumber => _correctNumber;

        public event Action<UICellNumber> ClickCell;

        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _numberText;
        [SerializeField] private Image _background;
        [SerializeField] private UIHints _uiHints;

        private bool _looked;
        private ThemeConfigs _themeConfigs;

        private CellStatus _cellStatus;
        private bool _userInputNumber;
        private bool _correctNumber;

        public void Init(int number, int indexCell, int indexBlock)
        {
            Number = number;
            IndexCell = indexCell;
            IndexBlock = indexBlock;
            IndexCellVector = new Vector2Int((IndexCell - 1) % 9, (IndexCell - 1) / 9);

            _cellStatus = CellStatus.Empty;

            _correctNumber = _looked = Number != 0;
            if (_looked == false)
                _cellStatus = CellStatus.LevelNumber;

            _uiHints.Init();
            _uiHints.HideAll();

            RefreshUI();
        }

        public void SetUserNumber(int number)
        {
            if (_looked)
                return;

            if (Number == number)
            {
                ClearNumber();
                return;
            }

            _userInputNumber = true;
            _cellStatus = CellStatus.UserNumber;
            Number = number;
            
            RefreshUI();
            RefreshColor();
            HideHints();
        }

        public void CellCorrectNumber()
        {
            _correctNumber = true;
        }

        public void ClearNumber()
        {
            if (_looked)
                return;

            _correctNumber = false;
            _userInputNumber = false;
            _cellStatus = CellStatus.Empty;
            Number = 0;
            RefreshUI();
            RefreshColor();
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
        }

        public void Unselect()
        {
            _cellStatus = CellStatus.Unselect;

            RefreshColor();
        }

        public void Select()
        {
            _cellStatus = CellStatus.Select;

            RefreshColor();
        }

        public void SelectorLine()
        {
            _cellStatus = CellStatus.LineSelector;

            RefreshColor();
        }

        public void UpdateTheme(ThemeConfigs themeConfigs)
        {
            _themeConfigs = themeConfigs;

            RefreshUI();
        }

        public void Error()
        {
            _cellStatus = CellStatus.Error;
            _correctNumber = false;
            RefreshColor();
        }

        public void DeniesNumber()
        {
            _cellStatus = CellStatus.DeniesCell;
            RefreshColor();
        }

        private void RefreshColor()
        {
            switch (_cellStatus)
            {
                case CellStatus.LevelNumber:
                    _numberText.color = _themeConfigs.LevelNumberTextColor;
                    break;
                case CellStatus.UserNumber:
                    _numberText.color = _themeConfigs.UserTextColor;
                    break;
                case CellStatus.Empty:
                    break;
                case CellStatus.Select:
                    _background.color = _themeConfigs.SelectCellColor;
                    break;
                case CellStatus.Unselect:
                    _background.color = _themeConfigs.BaseCellColor;
                    break;
                case CellStatus.LineSelector:
                    _background.color = _themeConfigs.SelectorInLineCellColor;
                    break;
                case CellStatus.Error:
                    _numberText.color = _themeConfigs.ErrorTextColor;
                    break;
                case CellStatus.DeniesCell:
                    _background.color = _themeConfigs.CellDeniesUserInputColor;
                    break;
            }
        }

        public void SetHints(List<int> hints)
        {
            _uiHints.SetHints(hints);
        }
        
        private void HideHints()
        {
            _uiHints.HideAll();
        }
    }
}