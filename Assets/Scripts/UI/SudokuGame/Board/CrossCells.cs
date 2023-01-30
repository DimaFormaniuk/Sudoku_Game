using System.Collections.Generic;
using UI.SudokuGame.Cell;

namespace UI.SudokuGame.Board
{
    public class CrossCells : ICrossCells
    {
        private readonly IBoardData _boardData;

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

        public List<CellNumber> GetLinesNumbers(CellNumber cellNumber)
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

        public List<CellNumber> GetBlockNumbers(CellNumber cellNumber) =>
            GetBlockNumbersFull(cellNumber).FindAll(x => x.IndexCellVector != cellNumber.IndexCellVector);

        public List<CellNumber> GetBlockNumbersFull(CellNumber cellNumber) =>
            _boardData.BoardList.FindAll(x => x.IndexBlock == cellNumber.IndexBlock);

        public List<CellNumber> GetHorizontalLineNumbers(CellNumber cellNumber) => 
            GetHorizontalLineNumbersFull(cellNumber).FindAll(x => x.IndexBlock != cellNumber.IndexBlock);

        public List<CellNumber> GetVerticalLineNumbers(CellNumber cellNumber) => 
            GetVerticalLineNumbersFull(cellNumber).FindAll(x => x.IndexBlock != cellNumber.IndexBlock);

        public List<CellNumber> GetHorizontalLineNumbersFull(CellNumber cellNumber)
        {
            List<CellNumber> result = new List<CellNumber>();

            int x = cellNumber.IndexCellVector.x;

            for (int i = 0; i < _boardData.Size; i++)
                result.Add(_boardData.BoardArray[x, i]);

            return result;
        }

        public List<CellNumber> GetVerticalLineNumbersFull(CellNumber cellNumber)
        {
            List<CellNumber> result = new List<CellNumber>();

            int y = cellNumber.IndexCellVector.y;

            for (int i = 0; i < _boardData.Size; i++)
                result.Add(_boardData.BoardArray[i, y]);

            return result;
        }
    }
}