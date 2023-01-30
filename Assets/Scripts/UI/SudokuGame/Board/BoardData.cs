using System.Collections.Generic;
using UI.SudokuGame.Cell;

namespace UI.SudokuGame.Board
{
    public class BoardData : IBoardData
    {
        public int Size { get; private set; } = 9;
        public List<UIBlockCells> BlockCells => _uiBlockCells;
        public CellNumber[,] BoardArray => _boardArray;
        public List<CellNumber> BoardList => _boardList;
        public CellNumber SelectedCell => _selectedCell;

        private readonly List<UIBlockCells> _uiBlockCells;

        private CellNumber[,] _boardArray;
        private List<CellNumber> _boardList;
        private CellNumber _selectedCell;

        public BoardData(List<UIBlockCells> uiBlockCells)
        {
            _uiBlockCells = uiBlockCells;
        }

        public void InitBoard()
        {
            _boardArray = new CellNumber[Size, Size];
            _boardList = new List<CellNumber>();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    var vector2 = _uiBlockCells[i].UICellNumbers[j].IndexCellVector;
                    _boardArray[vector2.x, vector2.y] = _uiBlockCells[i].UICellNumbers[j];
                    _boardList.Add(_uiBlockCells[i].UICellNumbers[j]);
                }
            }

            _selectedCell = FindFirsEmptyCell();
        }

        public void SetSelectedCell(CellNumber cellNumber) =>
            _selectedCell = cellNumber;

        public void SetLevelNumber(List<int> parseData)
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

        private CellNumber FindFirsEmptyCell()
        {
            return _boardList.Find(x => x.Number == 0);
        }
    }
}