using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    [CreateAssetMenu(menuName = "Static Data/Prefab static data", fileName = "UIPrefabStaticData")]
    public class UIPrefabStaticData : ScriptableObject
    {
        public List<PrefabConfig> Configs;
    }
}