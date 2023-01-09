using Sudoku.Scripts.CodeBase.Data;

namespace Sudoku.Scripts.CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress PlayerProgress { get; set; }
    }
}