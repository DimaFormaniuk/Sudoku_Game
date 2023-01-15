using System.Collections.Generic;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Logic.Services;
using CodeBase.StaticData;
using CodeBase.UI.SelectLevel;
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
            var obj = CreatePrefab(PrefabId.Menu);
            //obj.GetComponent<UISelectLevel>().Init(_progressService);

            return obj;
        }

        public GameObject CreateGame()
        {
            return CreatePrefab(PrefabId.Game);
        }
        
        public GameObject CreateEndGame()
        {
            return CreatePrefab(PrefabId.EndGame);
        }

        public void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);

            ProgressReaders.Add(progressReader);
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
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