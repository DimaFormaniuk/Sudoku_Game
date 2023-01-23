using System.Collections.Generic;

namespace CodeBase.UI.SudokuGame
{
    public interface IBoardData
    {
        int Size { get; }
        List<UIBlockCells> BlockCells { get; }
        UICellNumber[,] BoardArray { get; }
        List<UICellNumber> BoardList { get; }
        UICellNumber SelectedCell { get; }
        void InitBoard();
        void SetSelectedCell(UICellNumber cellNumber);
        void SetLevelNumber(List<int> parseData);
    }
}