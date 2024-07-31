namespace Assets.CodeBase.Infrastructure.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }

    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload sceneName);
    }

    public interface IPayloadedState1<TPayload, TPayload1> : IExitableState
    {
        void Enter(TPayload sceneName, TPayload1 payload);
    }

    public interface IExitableState
    {
        void Exit();
    }
}
