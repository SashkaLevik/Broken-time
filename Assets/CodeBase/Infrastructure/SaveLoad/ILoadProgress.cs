using CodeBase.Data;

namespace CodeBase.Infrastructure.SaveLoad
{
    public interface ILoadProgress
    {
        public void Load(PlayerProgress progress);
    }
}
