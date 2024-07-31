using Assets.CodeBase.Infrastructure.AssetManagment;
using Assets.CodeBase.Infrastructure.Factory;
using Assets.CodeBase.Infrastructure.RunGameLogic;
using Assets.CodeBase.Infrastructure.Services;

namespace Assets.CodeBase.Infrastructure.States
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
            RegisterToyData();
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>(),
                _services.Single<IGameFactory>()));
        }

        private void LoadProgress()
        {
            _stateMachine.Enter<ProgressState>();
        }

        private void RegisterToyData()
        {
            //IToyDataService toyData = new ToyDataService();
            //toyData.Load();
            //_services.RegisterSingle(toyData);
        }
    }
}