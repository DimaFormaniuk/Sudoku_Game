using Infrastructure.Services;
using Infrastructure.Services.Sound;

namespace UI.SudokuGame.Board
{
    public class BoardSound : IBoardSound
    {
        private readonly ISoundService _soundService;
        private readonly IBoardData _boardData;

        public BoardSound(IBoardData boardData)
        {
            _boardData = boardData;
            _soundService = AllServices.Container.Single<ISoundService>();
        }

        public void InputNumber()
        {
            if (_boardData.SelectedCell.Number == 0)
                return;

            if (_boardData.SelectedCell.CorrectNumber)
                _soundService.Play(SoundType.CorrectNumber);
            else
                _soundService.Play(SoundType.ErrorNumber);
        }

        public void ClickClear()
        {
            _soundService.Play(SoundType.CleanCell);
        }

        public void PlayCompleteBlockOrLine()
        {
            _soundService.Play(SoundType.CompleteBlock);
        }
    }
}