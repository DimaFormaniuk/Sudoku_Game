using System.Collections.Generic;
using Infrastructure.Services.Factory;

namespace Infrastructure.Services.Theme
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