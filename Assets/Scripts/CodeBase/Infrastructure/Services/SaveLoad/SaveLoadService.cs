using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.UI.Services.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";

        private readonly IPersistentProgressService _progressService;
        private readonly IUIFactory _uiFactory;

        public SaveLoadService(IPersistentProgressService progressService, IUIFactory uiFactory)
        {
            _progressService = progressService;
            _uiFactory = uiFactory;
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _uiFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.PlayerProgress);

            PlayerPrefs.SetString(ProgressKey, _progressService.PlayerProgress.ToJson());

            Debug.Log("Save");
        }

        public PlayerProgress LoadProgress()
        {
            Debug.Log("Load");

            return PlayerPrefs.GetString(ProgressKey).AsDeserelize<PlayerProgress>();
        }
        
        public void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _uiFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.PlayerProgress);
        }
    }
}