using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
    public interface IUIFactoryService : IService, ICleanup
    {
        void Registered(IRegistered registered);
        GameObject CreateUIRoot();
        GameObject CreateMenu();
        GameObject CreateNewGame();
        GameObject CreateContinueGame();
        GameObject CreateEndGame();
        void ClearRoot();
        void CreateLogo();
    }
}