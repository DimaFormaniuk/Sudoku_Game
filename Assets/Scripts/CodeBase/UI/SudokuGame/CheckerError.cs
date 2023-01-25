using System.Collections.Generic;

namespace CodeBase.UI.SudokuGame
{
    public class CheckerError : ICheckerError
    {
        private ICrossCells _crossCells;
        private IBoardData _boardData;

        public CheckerError(IBoardData boardData, ICrossCells crossCells)
        {
            _boardData = boardData;
            _crossCells = crossCells;
        }

        public void CheckError()
        {
            CheckErrorNotSelectCell();
            CheckErrorSelectCell();
        }

        private void CheckErrorSelectCell()
        {
            List<CellNumber> cells = _crossCells.GetCrossCells(_boardData.SelectedCell);
            cells.ForEach(x =>
            {
                if (x.Number != 0 && x.Number == _boardData.SelectedCell.Number)
                    x.DeniesNumber();
            });
        }

        private void CheckErrorNotSelectCell()
        {
            foreach (var cellNumber in _boardData.BoardList)
            {
                bool correctNumber = true;
                if (cellNumber.LevelNumber == false && cellNumber.Number != 0)
                {
                    List<CellNumber> numbers = _crossCells.GetCrossCells(cellNumber);

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
    }
}