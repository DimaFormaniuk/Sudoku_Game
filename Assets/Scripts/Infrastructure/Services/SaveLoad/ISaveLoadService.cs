using System.Collections.Generic;
using Data;
using Infrastructure.Services.Factory;

namespace Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService : IService, IRegistered
    {
        List<ISavedProgressReader> AllLifeProgressReaders { get; }
        List<ISavedProgress> AllLifeProgressWriters { get; }
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void SaveProgress();
        PlayerProgress LoadProgress();
        void InformProgressReaders();
        void Cleanup();
        void Register(ISavedProgressReader progressReader);
        void RegisterAllLife(ISavedProgressReader progressReader);
    }
}