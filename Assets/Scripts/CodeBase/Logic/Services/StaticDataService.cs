using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData;
using CodeBase.UI.Services.Theme;
using UnityEngine;

namespace CodeBase.Logic.Services
{
    public class StaticDataService : IStaticDataService
    {
        private const string BaseResourcesPath = "StaticData/";
        private Dictionary<PrefabId, PrefabConfig> _prefabConfigs;
        private List<ThemeConfigData> _themeConfigs;

        public void Load()
        {
            LoadPrefabs();
            LoadTheme();
        }

        public PrefabConfig ForPrefab(PrefabId prefabId) =>
            _prefabConfigs.TryGetValue(prefabId, out PrefabConfig config)
                ? config
                : null;

        public List<ThemeConfigData> GetThemeConfigs()
        {
            return _themeConfigs;
        }

        private void LoadPrefabs()
        {
            _prefabConfigs = Resources
                .Load<UIPrefabStaticData>(BaseResourcesPath + "UI/UIPrefabStaticData")
                .Configs
                .ToDictionary(x => x.Type, x => x);
        }

        private void LoadTheme()
        {
            _themeConfigs = Resources
                .Load<ThemeStaticData>(BaseResourcesPath + "Theme/ThemeStaticData")
                .configs;
        }
    }
}