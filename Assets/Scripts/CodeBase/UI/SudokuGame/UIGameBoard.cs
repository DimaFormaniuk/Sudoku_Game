using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.SudokuGame
{
    public class UIGameBoard : MonoBehaviour
    {
        private const int Size = 9;

        [SerializeField] private List<UIBlockCells> _uiBlockCells;
        private UIInputNumbers _uiInputNumbers;

        private UICellNumber[,] _boardArray;
        private List<UICellNumber> _boardList;

        private UICellNumber _selectedCell;

        public void Init(List<int> parseData, UIInputNumbers uiInputNumbers)
        {
            _uiInputNumbers = uiInputNumbers;

            SetLevelNumber(parseData);
            InitBoard();
            Subscrible();
            _selectedCell = FindFirsEmptyCell();
        }

        private UICellNumber FindFirsEmptyCell()
        {
            return _boardList.Find(x => x.Number == 0);
        }

        private void OnDestroy()
        {
            Unsubscrible();
        }

        private void InitBoard()
        {
            _boardArray = new UICellNumber[Size, Size];
            _boardList = new List<UICellNumber>();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    var vector2 = _uiBlockCells[i].UICellNumbers[j].IndexCellVector;
                    _boardArray[vector2.x, vector2.y] = _uiBlockCells[i].UICellNumbers[j];
                    _boardList.Add(_uiBlockCells[i].UICellNumbers[j]);
                }
            }
        }

        private void SetLevelNumber(List<int> parseData)
        {
            int index = 0;
            int count = Size;

            for (int i = 0; i < _uiBlockCells.Count; i++)
            {
                List<int> number = parseData.GetRange(index, count);
                _uiBlockCells[i].Init(number, i + 1);
                index += count;
            }
        }

        private void Subscrible()
        {
            _uiInputNumbers.ClickNumber += OnInputNumber;
            _boardList.ForEach(x => x.ClickCell += OnClickCell);
        }

        private void Unsubscrible()
        {
            _uiInputNumbers.ClickNumber -= OnInputNumber;
            _boardList.ForEach(x => x.ClickCell -= OnClickCell);
        }

        private void OnInputNumber(int number)
        {
            _selectedCell.SetUserNumber(number);
        }

        private void OnClickCell(UICellNumber cellNumber)
        {
            _selectedCell = cellNumber;

            RefreshBoard();
        }

        private void RefreshBoard()
        {
            RefreshAllCells();
            RefreshBlockColor();
            RefreshLinesColor();
            RefreshCellSelectorColor();
        }

        private void RefreshAllCells()
        {
            _boardList.ForEach(x => x.Unselect());
        }

        private void RefreshBlockColor()
        {
            _uiBlockCells.Find(x => x.IndexBlock == _selectedCell.IndexBlock).SelectorInBlock();
        }

        private void RefreshLinesColor()
        {
            int x = _selectedCell.IndexCellVector.x;
            int y = _selectedCell.IndexCellVector.y;

            for (int i = 0; i < Size; i++)
            {
                _boardArray[x, i].SelectorLine();
                _boardArray[i, y].SelectorLine();
            }
        }

        private void RefreshCellSelectorColor()
        {
            _selectedCell.Select();
        }
    }
}