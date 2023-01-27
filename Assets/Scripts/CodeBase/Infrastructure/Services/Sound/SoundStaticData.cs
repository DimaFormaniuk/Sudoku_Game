using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Sound
{
    [CreateAssetMenu(menuName = "Static Data/Sound Static Data", fileName = "SoundStaticData")]
    public class SoundStaticData : ScriptableObject
    {
        public List<SoundConfigs> configs;
    }
}