using System.Collections.Generic;
using UI.SudokuGame.Cell;

namespace UI.SudokuGame.Board
{
    public interface ICrossCells
    {
        List<CellNumber> GetCrossCells(CellNumber x);
        List<CellNumber> GetCrossCellsFull(CellNumber cellNumber);
        List<CellNumber> GetLinesNumbers(CellNumber cellNumber);
        List<CellNumber> GetBlockNumbers(CellNumber cellNumber);
        List<CellNumber> GetBlockNumbersFull(CellNumber cellNumber);
        List<CellNumber> GetHorizontalLineNumbers(CellNumber cellNumber);
        List<CellNumber> GetVerticalLineNumbers(CellNumber cellNumber);
        List<CellNumber> GetHorizontalLineNumbersFull(CellNumber boardDataSelectedCell);
        List<CellNumber> GetVerticalLineNumbersFull(CellNumber boardDataSelectedCell);
    }
}