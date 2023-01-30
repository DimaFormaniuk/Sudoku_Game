using System.Collections.Generic;
using Infrastructure.Services.Theme;
using UI.SudokuGame.Cell;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SudokuGame.Board
{
    public class UIBlockCells : MonoBehaviour, IThemeReader
    {
        public List<CellNumber> UICellNumbers => _uiCellNumbers;

        [SerializeField] private List<CellNumber> _uiCellNumbers;
        [SerializeField] private List<Image> _lines;
        private int _calculateIndex;
        private ThemeConfigData _themeConfigData;

        public int IndexBlock { get; private set; }

        public void Init(List<int> number, int index)
        {
            IndexBlock = index;

            for (var i = 0; i < _uiCellNumbers.Count; i++)
                _uiCellNumbers[i].Init(number[i], CalculateIndex(i), IndexBlock);
        }

        private Vector2Int CalculateIndex(int i)
        {
            int x = ((i / 3) * 9);
            int y = i % 3;
            int k = ((IndexBlock - 1) / 3) * 3 * 9;
            int l = ((IndexBlock - 1) % 3) * 3;

            _calculateIndex = x + y + k + l;

            //Debug.LogError($"i={_calculateIndex} x={x} y={y} k={k} l={l}");

            return new Vector2Int(_calculateIndex % 9, _calculateIndex / 9);
        }

        public void SelectorInBlock()
        {
            _uiCellNumbers.ForEach(x => x.SelectorLine());
        }

        public void UpdateTheme(ThemeConfigData themeConfigData)
        {
            _themeConfigData = themeConfigData;

            RefreshColor();
        }

        private void RefreshColor()
        {
            _lines.ForEach(x => x.color = _themeConfigData.BlockLinesColor);
        }

        public void SetUserNumbers(List<int> number)
        {
            for (var i = 0; i < _uiCellNumbers.Count; i++)
                if (number[i] != 0)
                    _uiCellNumbers[i].SetUserNumber(number[i]);
        }

        public void SetUserHints(List<List<int>> hints)
        {
            for (var i = 0; i < _uiCellNumbers.Count; i++)
                if (hints[i].Count != 0)
                    _uiCellNumbers[i].SetHints(hints[i]);
        }
    }
}