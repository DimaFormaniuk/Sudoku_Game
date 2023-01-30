namespace UI.SudokuGame.Board
{
    public interface IRefresherBoardNumbers
    {
        void InputNumber(int number);
        void RefreshBoard();
        void ShowAllTheSameNumber();
    }
}