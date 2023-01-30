using Data;

namespace Infrastructure.Services.SaveLoad
{
    public interface ISavedProgressReader
    {
        public void LoadProgress(PlayerProgress playerProgress);
    }
}