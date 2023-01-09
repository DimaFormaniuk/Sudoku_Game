using Sudoku.Scripts.CodeBase.Data;

namespace Sudoku.Scripts.CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface ISavedProgress : ISavedProgressReader
    {
        public void UpdateProgress(PlayerProgress playerProgress);
    }
}