using System.Collections.Generic;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic.Services;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
    public class IuiFactoryService : IUIFactoryService
    {
        private List<IRegistered> _listRegistered = new List<IRegistered>();

        private readonly IStaticDataService _staticData;
        private readonly IPersistentProgressService _progressService;

        private Transform _uiRoot;

        private List<GameObject> _gameObjectsInRoot = new List<GameObject>();

        public IuiFactoryService(IStaticDataService staticData, IPersistentProgressService progressService)
        {
            _staticData = staticData;
            _progressService = progressService;
        }

        public void Registered(IRegistered registered)
        {
            _listRegistered.Add(registered);
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
            prefabInRoot.GetComponent<SudokuGame.SudokuGame>().InitNewGame(_progressService.Progress.LevelMenuData);

            return prefabInRoot;
        }

        public GameObject CreateContinueGame()
        {
            var prefabInRoot = CreatePrefabInRoot(PrefabId.Game);
            prefabInRoot.GetComponent<SudokuGame.SudokuGame>().InitContinueGame(_progressService.Progress.LastGameData);

            return prefabInRoot;
        }

        public GameObject CreateEndGame()
        {
            return CreatePrefabInRoot(PrefabId.EndGame);
        }

        public void ClearRoot()
        {
            foreach (GameObject gameObject in _gameObjectsInRoot)
                Object.Destroy(gameObject);

            _gameObjectsInRoot.Clear();
        }

        private GameObject CreatePrefabInRoot(PrefabId prefabId)
        {
            var prefab = CreatePrefab(prefabId);
            _gameObjectsInRoot.Add(prefab);

            return prefab;
        }

        private GameObject CreatePrefab(PrefabId prefabId)
        {
            var config = _staticData.ForPrefab(prefabId);
            var prefab = Object.Instantiate(config.Prefab, _uiRoot);

            RegisterWatchers(prefab);

            return prefab;
        }

        private void RegisterWatchers(GameObject gameObject)
        {
            _listRegistered.ForEach(x => x.Register(gameObject));
        }

        public void Cleanup()
        {
            _listRegistered.ForEach(x => x.Cleanup());
        }
    }
}