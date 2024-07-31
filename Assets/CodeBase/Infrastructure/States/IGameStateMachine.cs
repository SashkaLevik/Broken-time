using Assets.CodeBase.Infrastructure.Services;

namespace Assets.CodeBase.Infrastructure.States
{
    public interface IGameStateMachine : IService
    {
        public void Enter<TState>() where TState : class, IState;
        public void Enter<TState, TPayload>(TPayload sceneName) where TState : class, IPayloadedState<TPayload>;
        //public void Enter<TState, TPayload>(TPayload sceneName, ToyStaticData toyData) where TState : class, IPayloadedState1<TPayload, ToyStaticData>;
    }
}
