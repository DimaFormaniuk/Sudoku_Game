using System.Collections.Generic;
using Data;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";

        public List<ISavedProgressReader> AllLifeProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> AllLifeProgressWriters { get; } = new List<ISavedProgress>();
        
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();
        
        private readonly IPersistentProgressService _progressService;

        public SaveLoadService(IPersistentProgressService progressService)
        {
            _progressService = progressService;
        }

        public void SaveProgress()
        {
            SaveProgressAllLife();
            
            foreach (ISavedProgress progressWriter in ProgressWriters)
                progressWriter.UpdateProgress(_progressService.Progress);

            PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(ProgressKey).AsDeserelize<PlayerProgress>();
        }
        
        public void InformProgressReaders()
        {
            InformProgressReadersAllLife();
            
            foreach (ISavedProgressReader progressReader in ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }

        public void Register(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }
        
        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        public void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);

            ProgressReaders.Add(progressReader);
        }

        public void RegisterAllLife(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                AllLifeProgressWriters.Add(progressWriter);

            AllLifeProgressReaders.Add(progressReader);
        }
        
        private void InformProgressReadersAllLife()
        {
            foreach (ISavedProgressReader allLifeProgressReader in AllLifeProgressReaders)
                allLifeProgressReader.LoadProgress(_progressService.Progress);
        }
        
        public void SaveProgressAllLife()
        {
            foreach (ISavedProgress allLifeprogressWriter in AllLifeProgressWriters)
                allLifeprogressWriter.UpdateProgress(_progressService.Progress);
        }
    }
}