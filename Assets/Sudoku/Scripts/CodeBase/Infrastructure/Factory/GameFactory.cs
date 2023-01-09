using System.Collections.Generic;
using Sudoku.Scripts.CodeBase.Infrastructure.AssetManagement;
using Sudoku.Scripts.CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Sudoku.Scripts.CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressesWriters { get; } = new List<ISavedProgress>();

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public void CreateMenu()
        {
            InstantiateRegistered(AssetPath.MenuPath);
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressesWriters.Clear();
        }

        private GameObject InstantiateRegistered(string path)
        {
            GameObject gameObject = _assets.Instantiate(path);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader)
        {
            ProgressReaders.Add(progressReader);

            if (progressReader is ISavedProgress progressWriter)
                ProgressesWriters.Add(progressWriter);
        }
    }
}