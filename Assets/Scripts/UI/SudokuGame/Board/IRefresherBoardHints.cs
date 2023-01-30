namespace UI.SudokuGame.Board
{
    public interface IRefresherBoardHints
    {
        void InputHint(int number);
        void AutoSetHints();
        void RefreshUserInputHints();
        bool CanInputHint();
    }
}