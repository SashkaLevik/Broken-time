using CodeBase.GameEnvironment.UI.Windows;

namespace CodeBase.Infrastructure.Services
{
    public interface IStaticDataService : IService
    {
        void LoadWindowData();
        WindowConfig ForWindow(WindowId windowId);
    }
}