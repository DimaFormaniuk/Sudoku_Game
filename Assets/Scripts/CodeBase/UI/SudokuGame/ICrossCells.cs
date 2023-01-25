using System.Collections.Generic;

namespace CodeBase.UI.SudokuGame
{
    public interface ICrossCells
    {
        List<CellNumber> GetCrossCells(CellNumber x);
        List<CellNumber> GetCrossCellsFull(CellNumber cellNumber);
    }
}