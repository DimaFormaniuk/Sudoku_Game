namespace CodeBase.UI.SudokuGame.Input
{
    public interface IInputListener
    {
        void InputNumber(int number);
        void InputHint(int number);
        void ClickClear();
        void RefreshInputHints();
        void AutoHints();
    }
}