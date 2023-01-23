using System.Collections.Generic;

namespace CodeBase.UI.SudokuGame
{
    public class RefresherBoardHints : IRefresherBoardHints
    {
        private IBoardData _boardData;
        private ICrossCells _crossCells;

        public RefresherBoardHints(IBoardData boardData, ICrossCells crossCells)
        {
            _crossCells = crossCells;
            _boardData = boardData;
        }

        public void InputHint(int number)
        {
            if (CheckPossibleHint(number))
                _boardData.SelectedCell.SetUserHint(number);
            else
                ShowDeniesForHints(number);
        }

        public void RefreshUserInputHints()
        {
            foreach (UICellNumber uiCellNumber in _boardData.BoardList)
            {
                List<int> list = uiCellNumber.GetHints();
                List<int> possibleNumbers = GetPossiblyHints(uiCellNumber);
                List<int> result = list.FindAll(x => possibleNumbers.Contains(x));
                uiCellNumber.SetHints(result);
            }
        }

        public bool CanInputHint()
        {
            return _boardData.SelectedCell.Number == 0;
        }

        public void AutoSetHints()
        {
            foreach (var cellNumber in _boardData.BoardList)
            {
                if (cellNumber.LevelNumber == false && cellNumber.Number == 0)
                {
                    var hints = GetPossiblyHints(cellNumber);

                    cellNumber.SetHints(hints);
                }
            }
        }

        private List<int> GetPossiblyHints(UICellNumber cellNumber)
        {
            List<int> hints = new List<int>();
            for (int i = 1; i <= _boardData.Size; i++)
                hints.Add(i);

            List<UICellNumber> numbers = _crossCells.GetCrossCells(cellNumber);
            foreach (var uiCellNumber in numbers)
                if (uiCellNumber.Number != 0 && (uiCellNumber.CorrectNumber || uiCellNumber.LevelNumber))
                    if (hints.Contains(uiCellNumber.Number))
                        hints.Remove(uiCellNumber.Number);

            return hints;
        }

        private void ShowDeniesForHints(int number)
        {
            foreach (UICellNumber uiCellNumber in _crossCells.GetCrossCells(_boardData.SelectedCell))
                if (uiCellNumber.Number == number)
                    uiCellNumber.ShowDeniesForHints();
        }

        private bool CheckPossibleHint(int number)
        {
            return GetPossiblyHints(_boardData.SelectedCell).Contains(number);
        }
    }
}