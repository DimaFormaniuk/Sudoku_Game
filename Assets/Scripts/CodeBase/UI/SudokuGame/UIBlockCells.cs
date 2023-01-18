using System.Collections.Generic;
using CodeBase.UI.Services.Theme;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.SudokuGame
{
    public class UIBlockCells : MonoBehaviour, IThemeReader
    {
        public List<UICellNumber> UICellNumbers => _uiCellNumbers;

        [SerializeField] private List<UICellNumber> _uiCellNumbers;
        [SerializeField] private List<Image> _lines;
        private int _calculateIndex;
        private ThemeConfigs _themeConfigs;

        public int IndexBlock { get; private set; }

        public void Init(List<int> number, int index)
        {
            IndexBlock = index;

            for (var i = 0; i < _uiCellNumbers.Count; i++)
            {
                int indexCell = CalculateIndex(i);
                _uiCellNumbers[i].Init(number[i], indexCell, IndexBlock);
            }
        }

        private int CalculateIndex(int i)
        {
            int x = ((i / 3) * 9);
            int y = i % 3;
            int k = ((IndexBlock - 1) / 3) * 3 * 9;
            int l = ((IndexBlock - 1) % 3) * 3;

            _calculateIndex = 1 + x + y + k + l;

            //Debug.LogError($"i={_calculateIndex} x={x} y={y} k={k} l={l}");

            return _calculateIndex;
        }

        public void SelectorInBlock()
        {
            _uiCellNumbers.ForEach(x => x.SelectorLine());
        }

        public void UpdateTheme(ThemeConfigs themeConfigs)
        {
            _themeConfigs = themeConfigs;

            RefreshColor();
        }

        private void RefreshColor()
        {
            _lines.ForEach(x => x.color = _themeConfigs.BlockLinesColor);
        }
    }
}