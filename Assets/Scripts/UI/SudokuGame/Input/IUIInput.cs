using System.Collections.Generic;

namespace UI.SudokuGame.Input
{
    public interface IUIInput
    {
        void RefreshLeftNumber(int number, int count);
        void HintsInCell(List<int> numbers);
    }
}