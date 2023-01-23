using System;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.UI.SudokuGame
{
    public class CheckerEndGame : ICheckerEndGame
    {
        private IGameStateMachine _stateMachine;

        private IBoardData _boardData;
        private Action _endGame;

        public CheckerEndGame(IBoardData boardData, Action endGame)
        {
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();

            _boardData = boardData;
            _endGame = endGame;
        }

        public void CheckEndGame()
        {
            if (_boardData.BoardList.FindAll(x => x.CorrectNumber == false).Count == 0)
            {
                Debug.LogError("Win game");

                _endGame?.Invoke();

                _stateMachine.Enter<EndGameState>();
            }
        }
    }
}