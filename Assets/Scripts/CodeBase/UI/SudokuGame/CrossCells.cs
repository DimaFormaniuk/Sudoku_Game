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

        public List<UICellNumber> GetCrossCells(UICellNumber x)
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

            for (int i = 0; i < _boardData.Size; i++)
            {
                if (_boardData.BoardArray[x, i].IndexBlock != uiCellNumber.IndexBlock)
                    result.Add(_boardData.BoardArray[x, i]);
                if (_boardData.BoardArray[i, y].IndexBlock != uiCellNumber.IndexBlock)
                    result.Add(_boardData.BoardArray[i, y]);
            }

            return result;
        }

        private List<UICellNumber> GetBlockNumbers(UICellNumber uiCellNumber) =>
            _boardData.BoardList.FindAll(x => x.IndexBlock == uiCellNumber.IndexBlock
                                              && x.IndexCell != uiCellNumber.IndexCell);
    }
}