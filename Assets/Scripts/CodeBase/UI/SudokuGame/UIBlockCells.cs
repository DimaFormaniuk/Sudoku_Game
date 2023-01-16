using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.SudokuGame
{
    public class UIBlockCells : MonoBehaviour
    {
        public List<UICellNumber> UICellNumbers => _uiCellNumbers;

        [SerializeField] private List<UICellNumber> _uiCellNumbers;

        public int IndexBlock { get; private set; }

        public void Init(List<int> number, int index)
        {
            for (var i = 0; i < _uiCellNumbers.Count; i++)
            {
                int indexCell = index * 10 + i + 1;
                _uiCellNumbers[i].Init(number[i], indexCell);
            }
        }
    }
}