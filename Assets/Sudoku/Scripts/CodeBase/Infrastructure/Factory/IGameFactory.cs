using Sudoku.Scripts.CodeBase.Infrastructure.Services;

namespace Sudoku.Scripts.CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        void CreateMenu();
    }
}