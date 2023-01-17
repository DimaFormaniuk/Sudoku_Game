using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.SudokuGame
{
    public class UIBlockCells : MonoBehaviour
    {
        public List<UICellNumber> UICellNumbers => _uiCellNumbers;

        [SerializeField] private List<UICellNumber> _uiCellNumbers;
        private int _calculateIndex;

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
    }
}