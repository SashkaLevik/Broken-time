using Assets.CodeBase.Infrastructure.Services;
using Assets.CodeBase.Infrastructure.States;

namespace Assets.CodeBase.Infrastructure.RunGameLogic
{
    public class Game
    {

        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, AllServices.Container);
        }
    }
}