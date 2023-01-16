using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.SudokuGame
{
    public class UIGameBoard : MonoBehaviour
    {
        [SerializeField] private List<UIBlockCells> _uiBlockCells;
        private UIInputNumbers _uiInputNumbers;

        private Dictionary<int, UICellNumber> _board = new Dictionary<int, UICellNumber>();

        private UICellNumber _selectedCell;
        
        public void Init(List<int> parseData, UIInputNumbers uiInputNumbers)
        {
            _uiInputNumbers = uiInputNumbers;
            
            SetLevelNumber(parseData);
            InitDictionary();
            Subscrible();

            _selectedCell = _board[11];
        }

        private void OnDestroy()
        {
            Unsubscrible();
        }

        private void SetLevelNumber(List<int> parseData)
        {
            int index = 0;
            int count = 9;

            for (var i = 0; i < _uiBlockCells.Count; i++)
            {
                List<int> number = parseData.GetRange(index, count);
                _uiBlockCells[i].Init(number, i + 1);
                index += count;
            }
        }

        private void InitDictionary()
        {
            for (var i = 0; i < _uiBlockCells.Count; i++)
            for (int j = 0; j < _uiBlockCells[i].UICellNumbers.Count; j++)
                _board.Add(_uiBlockCells[i].UICellNumbers[j].IndexCell, _uiBlockCells[i].UICellNumbers[j]);
        }

        private void Subscrible()
        {
            _uiInputNumbers.ClickNumber += OnInputNumber;
            foreach (KeyValuePair<int, UICellNumber> uiCellNumber in _board)
                uiCellNumber.Value.ClickCell += OnClickCell;
        }

        private void Unsubscrible()
        {
            _uiInputNumbers.ClickNumber -= OnInputNumber;
            foreach (KeyValuePair<int, UICellNumber> uiCellNumber in _board)
                uiCellNumber.Value.ClickCell -= OnClickCell;
        }

        private void OnInputNumber(int number)
        {
            _selectedCell.SetUserNumber(number);
        }

        private void OnClickCell(UICellNumber cellNumber)
        {
            _selectedCell = cellNumber;
        }
    }
}