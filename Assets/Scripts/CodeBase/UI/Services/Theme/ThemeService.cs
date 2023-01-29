using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Logic.Services;
using UnityEngine;

namespace CodeBase.UI.Services.Theme
{
    public class ThemeService : IThemeService, ISavedProgress
    {
        public List<IThemeReader> ThemeReaders { get; private set; } = new List<IThemeReader>();
        public List<ThemeConfigData> ListThemeConfigs => _themeConfigs;

        public MainThemeConfigData MainThemeConfigs { get; private set; } 

        private readonly IStaticDataService _staticDataService;

        private List<ThemeConfigData> _themeConfigs;
        private int _index = 0;

        public ThemeConfigData CurrentTheme => _themeConfigs[_index];

        public ThemeService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;

            _themeConfigs = _staticDataService.GetThemeConfigs();
            MainThemeConfigs = _staticDataService.GetMainThemeConfigData();
        }

        public void Register(GameObject gameObject)
        {
            foreach (IThemeReader themeReader in gameObject.GetComponentsInChildren<IThemeReader>())
                ThemeReaders.Add(themeReader);
        }

        public void ChangeTheme(int index)
        {
            _index = index;

            InfomThemeListeners();
        }

        public void InfomThemeListeners()
        {
            ThemeReaders.ForEach(x => x.UpdateTheme(_themeConfigs[_index]));
        }

        public void Cleanup()
        {
            ThemeReaders.Clear();
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            _index = playerProgress.ThemeData.IndexTheme;
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.ThemeData.IndexTheme = _index;
        }
    }
}