using Assets.CodeBase.Data;

namespace Assets.CodeBase.Infrastructure.SaveLoad
{
    public interface ILoadProgress
    {
        public void Load(PlayerProgress progress);
    }
}
