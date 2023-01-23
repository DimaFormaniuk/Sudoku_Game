namespace CodeBase.UI.SudokuGame
{
    public interface IRefresherBoardNumbers
    {
        void InputNumber(int number);
        void RefreshBoard();
        void ShowAllTheSameNumber();
    }
}