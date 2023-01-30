using Infrastructure.Services;
using Infrastructure.Services.Sound;
using UnityEngine;

namespace UI.EndGame
{
    public class EndGame : MonoBehaviour
    {
        private void Awake()
        {
            var soundService = AllServices.Container.Single<ISoundService>();
            soundService.Play(SoundType.LevelCompleted);
        }
    }
}
