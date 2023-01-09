using Sudoku.Scripts.CodeBase.Infrastructure.Services;
using Sudoku.Scripts.CodeBase.Infrastructure.States;

namespace Sudoku.Scripts.CodeBase.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);
        }
    }
}