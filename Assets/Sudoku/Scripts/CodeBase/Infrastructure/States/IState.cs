namespace Sudoku.Scripts.CodeBase.Infrastructure.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }

    public interface IPaylodedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }

    public interface IExitableState
    {
        void Exit();
    }
}