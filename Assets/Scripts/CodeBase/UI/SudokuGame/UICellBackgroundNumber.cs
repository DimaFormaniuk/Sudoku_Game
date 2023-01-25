using CodeBase.UI.Services.Theme;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.SudokuGame
{
    public class UICellBackgroundNumber : MonoBehaviour, IThemeReader
    {
        [SerializeField] private Image background;

        private ThemeConfigData _themeConfigData;
        
        private CellBackgroundStatus _cellBackgroundStatus;

        public void Init()
        {
            _cellBackgroundStatus = CellBackgroundStatus.Empty;
            
            RefreshUI();
        }
        
        public void UpdateTheme(ThemeConfigData themeConfigData)
        {
            _themeConfigData = themeConfigData;
            
            RefreshUI();
        }
        
        public void Unselect()
        {
            _cellBackgroundStatus = CellBackgroundStatus.Unselect;

            RefreshUI();
        }

        public void Select()
        {
            _cellBackgroundStatus = CellBackgroundStatus.Select;

            RefreshUI();
        }

        public void SelectorLine()
        {
            _cellBackgroundStatus = CellBackgroundStatus.LineSelector;

            RefreshUI();
        }

        public void DeniesNumber()
        {
            _cellBackgroundStatus = CellBackgroundStatus.DeniesCell;

            RefreshUI();
        }

        private void RefreshUI()
        {
            switch (_cellBackgroundStatus)
            {
                case CellBackgroundStatus.Empty:
                    background.color = _themeConfigData.BaseCellColor;
                    break;
                case CellBackgroundStatus.Select:
                    background.color = _themeConfigData.SelectCellColor;
                    break;
                case CellBackgroundStatus.Unselect:
                    background.color = _themeConfigData.BaseCellColor;
                    break;
                case CellBackgroundStatus.LineSelector:
                    background.color = _themeConfigData.SelectorInLineCellColor;
                    break;
                case CellBackgroundStatus.DeniesCell:
                    background.color = _themeConfigData.CellDeniesUserInputColor;
                    break;
            }
        }
    }
}