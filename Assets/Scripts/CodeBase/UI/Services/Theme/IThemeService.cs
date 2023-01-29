using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using CodeBase.UI.Services.Factory;

namespace CodeBase.UI.Services.Theme
{
    public interface IThemeService : IService, IRegistered
    {
        ThemeConfigData CurrentTheme { get; }
        public MainThemeConfigData MainThemeConfigs { get;} 
        List<ThemeConfigData> ListThemeConfigs { get; }
        void InfomThemeListeners();
        void Cleanup();
        void ChangeTheme(int index);
    }
}