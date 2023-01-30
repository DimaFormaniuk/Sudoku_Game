using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infrastructure.Services.Sound
{
    public class SoundController : MonoBehaviour
    {
        private Dictionary<SoundType, SoundConfigs> _soundConfigs;
        private Dictionary<SoundType, AudioSource> _audioSources;

        public void Init(List<SoundConfigs> soundConfigsList)
        {
            DontDestroyOnLoad(this);

            _soundConfigs = soundConfigsList.ToDictionary(x => x.SoundType, x => x);

            _audioSources = new Dictionary<SoundType, AudioSource>();
        }

        public void PlayBackgroundMusic()
        {
            Play(SoundType.BackgroundMusic);
            _audioSources[SoundType.BackgroundMusic].loop = true;
        }

        public void Play(SoundType soundType)
        {
            if (_audioSources.ContainsKey(soundType) == false)
                CreateAudioSource(soundType);

            Play(_audioSources[soundType]);
        }

        private void Play(AudioSource source)
        {
            var tmp = source.pitch;
            source.pitch += Random.Range(-0.1f, 0.1f);
            source.Play();
            source.pitch = tmp;
        }

        private void CreateAudioSource(SoundType soundType)
        {
            SoundConfigs configs = _soundConfigs[soundType];

            AudioSource tmp = new GameObject(soundType.ToString()).AddComponent<AudioSource>();
            tmp.transform.SetParent(transform);

            tmp.playOnAwake = false;
            tmp.clip = configs.Clip;
            tmp.volume = configs.Volume;
            tmp.pitch = configs.Pitch;

            _audioSources.Add(soundType, tmp);
        }
    }
}