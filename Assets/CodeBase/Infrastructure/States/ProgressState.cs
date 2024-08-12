using CodeBase.Data;
using CodeBase.Infrastructure.RunGameLogic;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.States
{
    public class ProgressState : IState
    {

        private const string MenuScene = "Menu";
        private const string Intro = "Intro";

        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly SceneLoader _sceneLoader;

        public ProgressState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            //_sceneLoader.Load(Intro);
            _gameStateMachine.Enter<MenuState, string>(MenuScene);
        }

        public void Exit() { }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress =
                _saveLoadService.LoadProgress()
                ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {

            var progress = new PlayerProgress(initialLevel: MenuScene);
            //progress.HeroState.ResetHP();

            return progress;
        }
    }
}