using Assets.CodeBase.Data;

namespace Assets.CodeBase.Infrastructure.Services
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}
