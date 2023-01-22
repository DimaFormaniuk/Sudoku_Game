namespace CodeBase.UI.SudokuGame.Input
{
    public interface IUIInputListener
    {
        void InputNumber(int number);
        void InputHint(int number);
        void ClickClear();
        void RefreshInputHints();
        void AutoHints();
    }
}