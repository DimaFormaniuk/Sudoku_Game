using System.Collections.Generic;

namespace CodeBase.UI.SudokuGame
{
    public class CrossCells : ICrossCells
    {
        private IBoardData _boardData;

        public CrossCells(IBoardData boardData)
        {
            _boardData = boardData;
        }

        public List<CellNumber> GetCrossCells(CellNumber x)
        {
            List<CellNumber> numbers = new List<CellNumber>();
            numbers.AddRange(GetBlockNumbers(x));
            numbers.AddRange(GetLinesNumbers(x));
            return numbers;
        }

        public List<CellNumber> GetCrossCellsFull(CellNumber cellNumber)
        {
            List<CellNumber> numbers = GetCrossCells(cellNumber);
            numbers.Add(cellNumber);
            return numbers;
        }

        private List<CellNumber> GetLinesNumbers(CellNumber cellNumber)
        {
            List<CellNumber> result = new List<CellNumber>();

            int x = cellNumber.IndexCellVector.x;
            int y = cellNumber.IndexCellVector.y;

            for (int i = 0; i < _boardData.Size; i++)
            {
                if (_boardData.BoardArray[x, i].IndexBlock != cellNumber.IndexBlock)
                    result.Add(_boardData.BoardArray[x, i]);
                if (_boardData.BoardArray[i, y].IndexBlock != cellNumber.IndexBlock)
                    result.Add(_boardData.BoardArray[i, y]);
            }

            return result;
        }

        private List<CellNumber> GetBlockNumbers(CellNumber cellNumber) =>
            _boardData.BoardList.FindAll(x => x.IndexBlock == cellNumber.IndexBlock
                                              && x.IndexCellVector != cellNumber.IndexCellVector);
    }
}