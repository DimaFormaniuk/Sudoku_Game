using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Sound;
using CodeBase.StaticData;
using CodeBase.UI.Services.Theme;

namespace CodeBase.Logic.Services
{
    public interface IStaticDataService : IService
    {
        void Load();
        PrefabConfig ForPrefab(PrefabId prefabId);

        List<ThemeConfigData> GetThemeConfigs();
        List<SoundConfigs> GetSoundConfigs();
    }
}