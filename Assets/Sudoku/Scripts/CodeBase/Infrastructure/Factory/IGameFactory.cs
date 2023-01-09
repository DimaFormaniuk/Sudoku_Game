using System.Collections.Generic;
using Sudoku.Scripts.CodeBase.Infrastructure.Services;
using Sudoku.Scripts.CodeBase.Infrastructure.Services.PersistentProgress;

namespace Sudoku.Scripts.CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        void CreateMenu();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressesWriters { get; }
        void Cleanup();
    }
}