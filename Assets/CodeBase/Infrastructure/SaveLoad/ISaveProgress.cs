using CodeBase.Data;

namespace CodeBase.Infrastructure.SaveLoad
{
    public interface ISaveProgress : ILoadProgress
    {
        public void Save(PlayerProgress progress);
    }
}
