using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Sound
{
    [Serializable]
    public class SoundConfigs
    {
        public SoundType SoundType;
        public AudioClip Clip;
        
        [Header("Settings")]
        [Range(0, 1)] public float Volume = 1f;
        [Range(-3, 3)] public float Pitch = 1f;
    }
}