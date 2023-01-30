using System.Collections.Generic;
using Data;

namespace UI.SudokuGame.Board
{
    public class LoadBoard : ILoadBoard
    {
        private IBoardData _boardData;

        public LoadBoard(IBoardData boardData)
        {
            _boardData = boardData;
        }

        public void LoadUserData(LastGameData progressLastGameData)
        {
            LoadUserNumbers(progressLastGameData.UserNumbers);
            LoadUserHints(progressLastGameData.Hints);
        }

        private void LoadUserNumbers(List<int> parseData)
        {
            int index = 0;
            int count = _boardData.Size;

            for (int i = 0; i < _boardData.BlockCells.Count; i++)
            {
                List<int> number = parseData.GetRange(index, count);
                _boardData.BlockCells[i].SetUserNumbers(number);
                index += count;
            }
        }

        private void LoadUserHints(List<HintsData> parseData)
        {
            int index = 0;
            int count = _boardData.Size;

            for (int i = 0; i < _boardData.BlockCells.Count; i++)
            {
                List<List<int>> hints = new List<List<int>>();

                for (int j = index; j < index + _boardData.Size; j++)
                {
                    hints.Add(parseData[j].Hints);
                }

                _boardData.BlockCells[i].SetUserHints(hints);
                index += count;
            }
        }
    }
}