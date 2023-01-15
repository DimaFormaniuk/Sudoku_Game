using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISavedProgressReader
    {
        public void LoadProgress(PlayerProgress playerProgress);
    }
}