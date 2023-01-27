using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Sound;
using UnityEngine;

namespace CodeBase.UI.EndGame
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
