using CodeBase.Data;

namespace CodeBase.UI.SudokuGame
{
    public interface ILoadBoard
    {
        void LoadUserData(LastGameData progressLastGameData);
    }
}