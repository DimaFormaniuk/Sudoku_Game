using Sudoku.Scripts.CodeBase.Infrastructure.AssetManagement;

namespace Sudoku.Scripts.CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public void CreateMenu()
        {
            _assets.Instantiate(AssetPath.MenuPath);
        }
    }
}