namespace CodeBase.UI.SudokuGame
{
    public interface IRefresherBoardHints
    {
        void InputHint(int number);
        void AutoSetHints();
        void RefreshUserInputHints();
        bool CanInputHint();
    }
}