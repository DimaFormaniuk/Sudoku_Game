using Sudoku.Scripts.CodeBase.Data;

namespace Sudoku.Scripts.CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface ISavedProgressReader
    {
        public void LoadProgress(PlayerProgress playerProgress);
    }
}