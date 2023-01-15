using CodeBase.Infrastructure.Services;
using CodeBase.StaticData;

namespace CodeBase.Logic.Services
{
    public interface IStaticDataService : IService
    {
        void Load();
        PrefabConfig ForPrefab(PrefabId prefabId);
    }
}