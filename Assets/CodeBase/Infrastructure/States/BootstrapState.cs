using CodeBase.Infrastructure.AssetManagment;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.RunGameLogic;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {

        private const string Initial = "Initial";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, onLoaded: LoadProgress);
        }

        public void Exit() { }

        private void RegisterServices()
        {
            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
            RegisterStaticData();
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>(),
                _services.Single<IStaticDataService>(), _services.Single<IPersistentProgressService>()));
            
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>(),
                _services.Single<IGameFactory>()));
        }

        private void LoadProgress()
        {
            _stateMachine.Enter<ProgressState>();
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadWindowData();
            _services.RegisterSingle(staticData);
            //IToyDataService toyData = new ToyDataService();
            //toyData.Load();
            //_services.RegisterSingle(toyData);
        }
    }
}