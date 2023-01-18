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

            RefreshBoard();
            RefreshLeftCountNumber();

            AutoSetHints();
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

            RefreshBoard();
            ShowAllTheSameNumber();
            CheckError();
            RefreshLeftCountNumber();
            CheckEndGame();
        }

        private void OnClickCell(UICellNumber cellNumber)
        {
            _selectedCell = cellNumber;

            CheckErrorSelectCell();
            RefreshBoard();
            ShowAllTheSameNumber();
        }

        private void CheckError()
        {
            CheckErrorNotSelectCell();
            CheckErrorSelectCell();
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

        private void ShowAllTheSameNumber()
        {
            if (_selectedCell.Number == 0)
                return;

            foreach (var uiCellNumber in _boardList)
            {
                if (uiCellNumber.Number == _selectedCell.Number)
                    uiCellNumber.Select();
            }
        }

        private void CheckErrorSelectCell()
        {
            List<UICellNumber> cells = GetCrossCells(_selectedCell);
            cells.ForEach(x =>
            {
                if (x.Number != 0 && x.Number == _selectedCell.Number)
                    x.DeniesNumber();
            });
        }

        private void CheckErrorNotSelectCell()
        {
            foreach (var cellNumber in _boardList)
            {
                bool correctNumber = true;
                if (cellNumber.LevelNumber == false && cellNumber.Number != 0)
                {
                    List<UICellNumber> numbers = GetCrossCells(cellNumber);

                    foreach (var number in numbers)
                    {
                        if (cellNumber.Number == number.Number && number.LevelNumber)
                        {
                            cellNumber.Error();
                            correctNumber = false;
                        }
                    }

                    if (correctNumber)
                        cellNumber.CellCorrectNumber();
                }
            }
        }

        private List<UICellNumber> GetCrossCells(UICellNumber x)
        {
            List<UICellNumber> numbers = new List<UICellNumber>();
            numbers.AddRange(GetBlockNumbers(x));
            numbers.AddRange(GetLinesNumbers(x));
            return numbers;
        }

        private List<UICellNumber> GetLinesNumbers(UICellNumber uiCellNumber)
        {
            List<UICellNumber> result = new List<UICellNumber>();

            int x = uiCellNumber.IndexCellVector.x;
            int y = uiCellNumber.IndexCellVector.y;

            for (int i = 0; i < Size; i++)
            {
                if (_boardArray[x, i].IndexBlock != uiCellNumber.IndexBlock)
                    result.Add(_boardArray[x, i]);
                if (_boardArray[i, y].IndexBlock != uiCellNumber.IndexBlock)
                    result.Add(_boardArray[i, y]);
            }

            return result;
        }

        private List<UICellNumber> GetBlockNumbers(UICellNumber uiCellNumber) =>
            _boardList.FindAll(x => x.IndexBlock == uiCellNumber.IndexBlock
                                    && x.IndexCell != uiCellNumber.IndexCell);

        private void CheckEndGame()
        {
            if (_boardList.FindAll(x => x.CorrectNumber == false).Count == 0)
            {
                Debug.LogError("Win game");
            }
        }

        private void RefreshLeftCountNumber()
        {
            foreach (var uiButtonNumber in _uiInputNumbers.UIButtonNumbers)
                uiButtonNumber.RefreshLeftNumber(CalculateLeftNumber(uiButtonNumber.Number));
        }

        private int CalculateLeftNumber(int number) =>
            Size - _boardList.FindAll(x => x.Number == number && (x.LevelNumber || x.CorrectNumber)).Count;

        public void AutoSetHints()
        {
            foreach (var cellNumber in _boardList)
            {
                if (cellNumber.LevelNumber == false && cellNumber.Number == 0)
                {
                    List<int> hints = new List<int>();
                    for (int i = 1; i <= Size; i++)
                        hints.Add(i);

                    List<UICellNumber> numbers = GetCrossCells(cellNumber);

                    foreach (var uiCellNumber in numbers)
                    {
                        if (uiCellNumber.Number != 0 && (uiCellNumber.CorrectNumber || uiCellNumber.LevelNumber))
                        {
                            if (hints.Contains(uiCellNumber.Number))
                            {
                                hints.Remove(uiCellNumber.Number);
                            }
                        }
                    }

                    cellNumber.SetHints(hints);
                }
            }
        }
    }
}