using System.Collections.Generic;
using UI.SudokuGame.Cell;

namespace UI.SudokuGame.Board
{
    public class CheckerCompleteBlock : ICheckerCompleteBlock
    {
        private IBoardData _boardData;
        private IBoardSound _boardSound;
        private ICrossCells _crossCells;

        public CheckerCompleteBlock(IBoardData boardData, ICrossCells crossCells, IBoardSound boardSound)
        {
            _crossCells = crossCells;
            _boardSound = boardSound;
            _boardData = boardData;
        }

        public void CheckCompleteBlockOrLine()
        {
            List<CellNumber> listCompleteCells = new List<CellNumber>(21);

            if (CheckCompleteBlock())
                listCompleteCells.AddRange(_crossCells.GetBlockNumbersFull(_boardData.SelectedCell));
            if (CheckCompleteHorizontal())
                listCompleteCells.AddRange(_crossCells.GetHorizontalLineNumbersFull(_boardData.SelectedCell));
            if (CheckCompleteVertical())
                listCompleteCells.AddRange(_crossCells.GetVerticalLineNumbersFull(_boardData.SelectedCell));

            InformCompleteBlock(listCompleteCells);
            if (listCompleteCells.Count != 0)
                _boardSound.PlayCompleteBlockOrLine();
        }

        private bool CheckCompleteBlock()
        {
            return _crossCells
                .GetBlockNumbersFull(_boardData.SelectedCell)
                .FindAll(x => x.CorrectNumber == false || x.Number == 0)
                .Count == 0;
        }

        private bool CheckCompleteHorizontal()
        {
            return _crossCells
                .GetHorizontalLineNumbersFull(_boardData.SelectedCell)
                .FindAll(x => x.CorrectNumber == false || x.Number == 0)
                .Count == 0;
        }

        private bool CheckCompleteVertical()
        {
            return _crossCells
                .GetVerticalLineNumbersFull(_boardData.SelectedCell)
                .FindAll(x => x.CorrectNumber == false || x.Number == 0)
                .Count == 0;
        }

        private void InformCompleteBlock(List<CellNumber> listCompleteCells)
        {
            listCompleteCells.ForEach(x => x.CompleteBlockOrLine());
        }
    }
}