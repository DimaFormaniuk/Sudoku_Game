namespace CodeBase.UI.SudokuGame
{
    public class RefresherBoardNumbers : IRefresherBoardNumbers
    {
        private readonly IBoardData _boardData;

        public void InputNumber(int number)
        {
            _boardData.SelectedCell.SetUserNumber(number);

            RefreshBoard();
            ShowAllTheSameNumber();
        }

        public RefresherBoardNumbers(IBoardData boardData)
        {
            _boardData = boardData;
        }

        public void RefreshBoard()
        {
            RefreshAllCells();
            RefreshBlockColor();
            RefreshLinesColor();
            RefreshCellSelectorColor();
        }

        public void ShowAllTheSameNumber()
        {
            if (_boardData.SelectedCell.Number == 0)
                return;

            foreach (var uiCellNumber in _boardData.BoardList)
            {
                if (uiCellNumber.Number == _boardData.SelectedCell.Number)
                    uiCellNumber.Select();
            }
        }

        private void RefreshAllCells()
        {
            _boardData.BoardList.ForEach(x => x.Unselect());
        }

        private void RefreshBlockColor()
        {
            _boardData.BlockCells.Find(x => x.IndexBlock == _boardData.SelectedCell.IndexBlock).SelectorInBlock();
        }

        private void RefreshLinesColor()
        {
            int x = _boardData.SelectedCell.IndexCellVector.x;
            int y = _boardData.SelectedCell.IndexCellVector.y;

            for (int i = 0; i < _boardData.Size; i++)
            {
                _boardData.BoardArray[x, i].SelectorLine();
                _boardData.BoardArray[i, y].SelectorLine();
            }
        }

        private void RefreshCellSelectorColor()
        {
            _boardData.SelectedCell.Select();
        }
    }
}