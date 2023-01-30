using System.Collections.Generic;
using Infrastructure.Services.Sound;
using Infrastructure.Services.Theme;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        PrefabConfig ForPrefab(PrefabId prefabId);
        List<ThemeConfigData> GetThemeConfigs();
        MainThemeConfigData GetMainThemeConfigData();
        List<SoundConfigs> GetSoundConfigs();
    }
}