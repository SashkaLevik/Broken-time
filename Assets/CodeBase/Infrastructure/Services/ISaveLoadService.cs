using CodeBase.Data;

namespace CodeBase.Infrastructure.Services
{
    public interface ISaveLoadService : IService
    {
        public void SaveProgress();

        public PlayerProgress LoadProgress();

        public void ResetProgress();

    }
}
