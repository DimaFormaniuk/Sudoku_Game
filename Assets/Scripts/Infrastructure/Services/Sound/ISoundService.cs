namespace Infrastructure.Services.Sound
{
    public interface ISoundService : IService
    {
        void Play(SoundType soundType);
    }
}