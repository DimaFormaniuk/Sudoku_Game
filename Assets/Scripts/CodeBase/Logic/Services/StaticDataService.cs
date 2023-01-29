using System.Collections.Generic;
using System.Linq;
using CodeBase.Infrastructure.Services.Sound;
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
        private List<SoundConfigs> _soundConfigs;
        private MainThemeConfigData _mainThemeConfigData;
        
        public void Load()
        {
            LoadPrefabs();
            LoadTheme();
            LoadSounds();
        }

        public PrefabConfig ForPrefab(PrefabId prefabId) =>
            _prefabConfigs.TryGetValue(prefabId, out PrefabConfig config)
                ? config
                : null;

        public List<ThemeConfigData> GetThemeConfigs()
        {
            return _themeConfigs;
        }

        public List<SoundConfigs> GetSoundConfigs()
        {
            return _soundConfigs;
        }

        public MainThemeConfigData GetMainThemeConfigData()
        {
            return _mainThemeConfigData;
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
            var tmp = Resources.Load<ThemeStaticData>(BaseResourcesPath + "Theme/ThemeStaticData");
            
            _themeConfigs = tmp.configs;
            _mainThemeConfigData = tmp.mainThemeConfigData;
        }
        
        private void LoadSounds()
        {
            _soundConfigs = Resources
                .Load<SoundStaticData>(BaseResourcesPath + "Sound/SoundStaticData")
                .configs;
        }
    }
}