using CodeBase.UI.Services.Theme;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.SudokuGame
{
    public class UICellNumber : MonoBehaviour, IThemeReader
    {
        public int Number { get; private set; }
        public bool LevelNumber => _cellNumberStatus == CellNumberStatus.LevelNumber;
        public bool CorrectNumber => _correctNumber;

        [SerializeField] private TMP_Text _numberText;
        [SerializeField] private Animation _animation;
        
        private CellNumberStatus _cellNumberStatus;
        private ThemeConfigData _themeConfigData;
        private bool _correctNumber;

        public void Init(int number)
        {
            Number = number;
            _cellNumberStatus = CellNumberStatus.Empty;
            _correctNumber = Number != 0;

            if (Number != 0)
                _cellNumberStatus = CellNumberStatus.LevelNumber;

            RefreshUI();
        }

        public void UpdateTheme(ThemeConfigData themeConfigData)
        {
            _themeConfigData = themeConfigData;
            
            RefreshUI();
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
            _correctNumber = false;
            Number = number;

            RefreshUI();
            _animation.Play("UserNumber");
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
            _cellNumberStatus = CellNumberStatus.ErrorNumber;

            RefreshUI();
        }

        public void CellCorrectNumber()
        {
            _cellNumberStatus = CellNumberStatus.CorrectNumber;
            _correctNumber = true;

            RefreshUI();
        }
        
        public void CompleteBlockOrLine()
        {
            _animation.Play("CompleteBlockOrLine");
        }

        public void ErrorInput()
        {
            Error();
            
            _animation.Play("ErrorNumber");
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
                case CellNumberStatus.CorrectNumber:
                    _numberText.color = _themeConfigData.UserTextColor;
                    break;
                case CellNumberStatus.Empty:
                    _numberText.color = _themeConfigData.LevelNumberTextColor;
                    break;
                case CellNumberStatus.ErrorNumber:
                    _numberText.color = _themeConfigData.ErrorTextColor;
                    break;
            }
        }
    }
}