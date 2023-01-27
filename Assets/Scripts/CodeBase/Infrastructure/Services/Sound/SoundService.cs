using CodeBase.Logic.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Sound
{
    public class SoundService : ISoundService
    {
        private SoundController _soundController;
        private readonly IStaticDataService _dataService;

        public SoundService(IStaticDataService dataService)
        {
            _dataService = dataService;

            InstantiateSoundController();

            _soundController.PlayBackgroundMusic();
        }
        
        public void Play(SoundType soundType)
        {
            _soundController.Play(soundType);
        }
        
        private void InstantiateSoundController()
        {
            _soundController = new GameObject("SoundController").AddComponent<SoundController>();
            _soundController.Init(_dataService.GetSoundConfigs());
        }
    }
}