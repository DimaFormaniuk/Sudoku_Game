using System.Collections.Generic;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Logic.Services;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        private readonly IStaticDataService _staticData;
        private readonly IPersistentProgressService _progressService;

        private Transform _uiRoot;

        private List<GameObject> _gameObjectsInRoot = new List<GameObject>();

        public UIFactory(IStaticDataService staticData, IPersistentProgressService progressService)
        {
            _staticData = staticData;
            _progressService = progressService;
        }

        public GameObject CreateUIRoot()
        {
            GameObject root = CreatePrefab(PrefabId.UIRoot);
            root.GetComponent<Canvas>().worldCamera = Camera.main;
            _uiRoot = root.transform;

            return root;
        }

        public GameObject CreateMenu()
        {
            return CreatePrefabInRoot(PrefabId.Menu);
        }

        public GameObject CreateNewGame()
        {
            var prefabInRoot = CreatePrefabInRoot(PrefabId.Game);
            prefabInRoot.GetComponent<SudokuGame.SudokuGame>().NewGame(_progressService.Progress.LevelMenuData);
            
            return prefabInRoot;
        }

        public GameObject CreateContinueGame()
        {
            var prefabInRoot = CreatePrefabInRoot(PrefabId.Game);
            prefabInRoot.GetComponent<SudokuGame.SudokuGame>().ContinueGame(_progressService.Progress.LastGameData);
            
            return prefabInRoot;
        }
        
        public GameObject CreateEndGame()
        {
            return CreatePrefabInRoot(PrefabId.EndGame);
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        public void ClearRoot()
        {
            foreach (GameObject gameObject in _gameObjectsInRoot)
                Object.Destroy(gameObject);
            
            _gameObjectsInRoot.Clear();
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);

            ProgressReaders.Add(progressReader);
        }

        private GameObject CreatePrefabInRoot(PrefabId prefabId)
        {
           var prefab = CreatePrefab(prefabId);
           _gameObjectsInRoot.Add(prefab);
           
           return prefab;
        }
        
        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private GameObject CreatePrefab(PrefabId prefabId)
        {
            var config = _staticData.ForPrefab(prefabId);
            var prefab = Object.Instantiate(config.Prefab, _uiRoot);

            RegisterProgressWatchers(prefab);

            return prefab;
        }
    }
}