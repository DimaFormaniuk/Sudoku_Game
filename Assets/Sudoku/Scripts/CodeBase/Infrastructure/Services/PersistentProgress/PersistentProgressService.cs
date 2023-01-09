using Sudoku.Scripts.CodeBase.Data;

namespace Sudoku.Scripts.CodeBase.Infrastructure.Services.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}