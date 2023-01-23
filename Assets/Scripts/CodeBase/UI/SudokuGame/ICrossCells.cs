using System.Collections.Generic;

namespace CodeBase.UI.SudokuGame
{
    public interface ICrossCells
    {
        List<UICellNumber> GetCrossCells(UICellNumber x);
    }
}