using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISavedProgress : ISavedProgressReader
    {
        public void UpdateProgress(PlayerProgress playerProgress);
    }
}