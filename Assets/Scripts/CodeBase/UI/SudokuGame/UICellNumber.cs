using CodeBase.UI.Services.Theme;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.SudokuGame
{
    public class UICellNumber : MonoBehaviour, IThemeReader
    {
        public int Number { get; private set; }
        public bool LevelNumber => _cellNumberStatus == CellNumberStatus.LevelNumber;
        public bool CorrectNumber => LevelNumber || _correctNumber;

        [SerializeField] private TMP_Text _numberText;

        private CellNumberStatus _cellNumberStatus;
        private ThemeConfigData _themeConfigData;
        private bool _correctNumber;
        
        public void Init(int number)
        {
            Number = number;

            _cellNumberStatus = CellNumberStatus.Empty;

            if (Number != 0)
                _cellNumberStatus = CellNumberStatus.LevelNumber;

            RefreshUI();
        }

        public void UpdateTheme(ThemeConfigData themeConfigData)
        {
            _themeConfigData = themeConfigData;
        }

        public void SetUserNumber(int number)
        {
            if (LevelNumber)
                return;
            
            if (Number == number)
            {
                ClearNumber();
                return;
            }

            Number = number;
            _cellNumberStatus = CellNumberStatus.UserNumber;

            RefreshUI();
        }

        public void ClearNumber()
        {
            if (LevelNumber)
                return;
            
            Number = 0;
            _cellNumberStatus = CellNumberStatus.Empty;
            _correctNumber = false;
            
            RefreshUI();
        }

        public void Error()
        {
            _cellNumberStatus = CellNumberStatus.Error;

            RefreshUI();
        }

        public void CellCorrectNumber()
        {
            _cellNumberStatus = CellNumberStatus.UserNumber;

            RefreshUI();
        }
        
        private void RefreshUI()
        {
            _numberText.text = $"{Number}";
            _numberText.gameObject.SetActive(Number != 0);

            if (Number == 0)
                return;

            switch (_cellNumberStatus)
            {
                case CellNumberStatus.LevelNumber:
                    _numberText.color = _themeConfigData.LevelNumberTextColor;
                    break;
                case CellNumberStatus.UserNumber:
                    _numberText.color = _themeConfigData.UserTextColor;
                    break;
                case CellNumberStatus.Empty:
                    _numberText.color = _themeConfigData.LevelNumberTextColor;
                    break;
                case CellNumberStatus.Error:
                    _numberText.color = _themeConfigData.ErrorTextColor;
                    break;
            }
        }
    }
}