using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
    public interface IUIFactory : IService, ICleanup
    {
        void Registered(IRegistered registered);
        GameObject CreateUIRoot();
        GameObject CreateMenu();
        GameObject CreateNewGame();
        GameObject CreateContinueGame();
        GameObject CreateEndGame();
        void ClearRoot();
        void RegisteredAllLife(IRegistered registered);
    }
}