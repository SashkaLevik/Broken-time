using Assets.CodeBase.Data;

namespace Assets.CodeBase.Infrastructure.Services
{
    public interface ISaveLoadService : IService
    {
        public void SaveProgress();

        public PlayerProgress LoadProgress();

        public void ResetProgress();

    }
}
