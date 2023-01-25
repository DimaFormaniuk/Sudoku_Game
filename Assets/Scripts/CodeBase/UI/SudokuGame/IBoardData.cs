using System.Collections.Generic;

namespace CodeBase.UI.SudokuGame
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