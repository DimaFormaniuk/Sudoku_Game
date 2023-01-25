using System.Collections.Generic;
using CodeBase.Data;

namespace CodeBase.UI.SudokuGame
{
    public class SaveBoard : ISaveBoard
    {
        private readonly IBoardData _boardData;

        public SaveBoard(IBoardData boardData)
        {
            _boardData = boardData;
        }
        
        public void Save(PlayerProgress playerProgress)
        {
            SaveUserNumbers(playerProgress);
            SaveUserHints(playerProgress);
        }

        private void SaveUserNumbers(PlayerProgress playerProgress)
        {
            List<int> numbers = new List<int>();
            foreach (UIBlockCells uiBlockCells in _boardData.BlockCells)
            {
                foreach (CellNumber uiCellNumber in uiBlockCells.UICellNumbers)
                {
                    if (uiCellNumber.LevelNumber)
                        numbers.Add(0);
                    else
                        numbers.Add(uiCellNumber.Number);
                }
            }

            playerProgress.LastGameData.UserNumbers = numbers;
        }

        private void SaveUserHints(PlayerProgress playerProgress)
        {
            List<HintsData> hints = new List<HintsData>();
            foreach (UIBlockCells uiBlockCells in _boardData.BlockCells)
            {
                foreach (CellNumber uiCellNumber in uiBlockCells.UICellNumbers)
                {
                    HintsData hintsData = new HintsData();
                    hintsData.Hints = uiCellNumber.GetHints();
                    hints.Add(hintsData);
                }
            }

            playerProgress.LastGameData.Hints = hints;
        }
    }
}