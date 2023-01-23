using System.Collections.Generic;

namespace CodeBase.UI.SudokuGame
{
    public class BoardData : IBoardData
    {
        public int Size { get; private set; } = 9;
        public List<UIBlockCells> BlockCells => _uiBlockCells;
        public UICellNumber[,] BoardArray => _boardArray;
        public List<UICellNumber> BoardList => _boardList;
        public UICellNumber SelectedCell => _selectedCell;

        private readonly List<UIBlockCells> _uiBlockCells;

        private UICellNumber[,] _boardArray;
        private List<UICellNumber> _boardList;
        private UICellNumber _selectedCell;

        public BoardData(List<UIBlockCells> uiBlockCells)
        {
            _uiBlockCells = uiBlockCells;
        }

        public void InitBoard()
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

            _selectedCell = FindFirsEmptyCell();
        }

        public void SetSelectedCell(UICellNumber cellNumber) =>
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

        private UICellNumber FindFirsEmptyCell()
        {
            return _boardList.Find(x => x.Number == 0);
        }
    }
}