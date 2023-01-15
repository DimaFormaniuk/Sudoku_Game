using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Logic.Services
{
    public class StaticDataService : IStaticDataService
    {
        private const string BaseResourcesPath = "StaticData/";
        
        private Dictionary<PrefabId, PrefabConfig> _windowConfigs;

        public void Load()
        {
            _windowConfigs = Resources
                .Load<UIPrefabStaticData>(BaseResourcesPath + "UI/UIPrefabStaticData")
                .Configs
                .ToDictionary(x => x.Type, x => x);
        }
        
        public PrefabConfig ForPrefab(PrefabId prefabId) =>
            _windowConfigs.TryGetValue(prefabId, out PrefabConfig config)
                ? config
                : null;
    }
}