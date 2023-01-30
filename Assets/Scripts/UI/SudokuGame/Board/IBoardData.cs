using System.Collections.Generic;
using UI.SudokuGame.Cell;

namespace UI.SudokuGame.Board
{
    public interface IBoardData
    {
        int Size { get; }
        List<UIBlockCells> BlockCells { get; }
        CellNumber[,] BoardArray { get; }
        List<CellNumber> BoardList { get; }
        CellNumber SelectedCell { get; }
        void InitBoard();
        void SetSelectedCell(CellNumber cellNumber);
        void SetLevelNumber(List<int> parseData);
    }
}