using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Logic.Services;
using UnityEngine;

namespace CodeBase.UI.Services.Theme
{
    public class ThemeService : IThemeService,ISavedProgress
    {
        public List<IThemeReader> ThemeReaders { get; private set; } = new List<IThemeReader>();

        private IStaticDataService _staticDataService;

        private List<ThemeConfigs> _themeConfigs;
        private int _index = 0;

        public ThemeService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;

            _themeConfigs = _staticDataService.GetThemeConfigs();
        }

        public void Register(GameObject gameObject)
        {
            foreach (IThemeReader themeReader in gameObject.GetComponentsInChildren<IThemeReader>())
                ThemeReaders.Add(themeReader);
        }

        public void NextTheme()
        {
            _index++;
            if (_index > _themeConfigs.Count - 1)
                _index = 0;
            
            InfomThemeListeners();
        }

        public void PreviousTheme()
        {
            _index--;
            if (_index < 0)
                _index = _themeConfigs.Count - 1;
            
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