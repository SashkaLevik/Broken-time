using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure.RunGameLogic
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