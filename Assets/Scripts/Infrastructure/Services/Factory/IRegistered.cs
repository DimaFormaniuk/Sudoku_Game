using UnityEngine;

namespace Infrastructure.Services.Factory
{
    public interface IRegistered : ICleanup
    {
        void Register(GameObject gameObject);
    }
}