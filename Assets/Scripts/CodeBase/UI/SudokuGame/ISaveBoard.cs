using CodeBase.Data;

namespace CodeBase.UI.SudokuGame
{
    public interface ISaveBoard
    {
        void Save(PlayerProgress playerProgress);
    }
}