using Sudoku.Scripts.CodeBase.Data;

namespace Sudoku.Scripts.CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService: IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}