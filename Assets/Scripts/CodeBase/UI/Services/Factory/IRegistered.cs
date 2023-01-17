using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
    public interface IRegistered : ICleanup
    {
        void Register(GameObject gameObject);
    }
}