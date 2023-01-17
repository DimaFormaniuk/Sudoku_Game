using CodeBase.Infrastructure.Services;
using CodeBase.UI.Services.Factory;

namespace CodeBase.UI.Services.Theme
{
    public interface IThemeService : IService, IRegistered
    {
        void NextTheme();
        void PreviousTheme();
        void InfomThemeListeners();
        void Cleanup();
    }
}