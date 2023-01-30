using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    [System.Serializable]
    public class PrefabConfig
    {
        public PrefabId Type;
        public GameObject Prefab;
    }
}