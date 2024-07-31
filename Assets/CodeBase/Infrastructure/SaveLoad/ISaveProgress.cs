using Assets.CodeBase.Data;

namespace Assets.CodeBase.Infrastructure.SaveLoad
{
    public interface ISaveProgress : ILoadProgress
    {
        public void Save(PlayerProgress progress);
    }
}
