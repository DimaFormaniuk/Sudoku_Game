using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Ads;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.UI.Services.Theme;
using CodeBase.UI.SudokuGame.Input;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.SudokuGame
{
    public class UIGameBoard : MonoBehaviour, IUIInputListener, ISavedProgress,IThemeReader
    {
        [SerializeField] private Image _backgroundGame;
        [SerializeField] private Image _background;
        
        [SerializeField] private List<UIBlockCells> _uiBlockCells;

        private ISaveLoadService _saveLoadService;
        private IAdsService _adsService;

        private IUIInput _input;

        private IBoardData _boardData;
        private ICrossCells _crossCells;
        private ICheckerError _checkerError;
        private ICheckerEndGame _checkerEndGame;
        private ISaveBoard _saveBoard;
        private ILoadBoard _loadBoard;
        private IRefresherBoardNumbers _refresherBoardNumbers;
        private IRefresherBoardHints _refresherBoardHints;

        public void Init(List<int> parseData, IUIInput input)
        {
            AllServices services = AllServices.Container;

            _saveLoadService = services.Single<ISaveLoadService>();
            _adsService = services.Single<IAdsService>();

            _input = input;

            _boardData = new BoardData(_uiBlockCells);
            _boardData.SetLevelNumber(parseData);
            _boardData.InitBoard();

            _crossCells = new CrossCells(_boardData);
            _checkerError = new CheckerError(_boardData, _crossCells);
            _checkerEndGame = new CheckerEndGame(_boardData, SaveGame);

            _saveBoard = new SaveBoard(_boardData);
            _loadBoard = new LoadBoard(_boardData);

            _refresherBoardNumbers = new RefresherBoardNumbers(_boardData);
            _refresherBoardHints = new RefresherBoardHints(_boardData, _crossCells);

            Subscrible();

            _refresherBoardNumbers.RefreshBoard();
            RefreshLeftCountNumber();
        }

        private void OnDestroy()
        {
            Unsubscrible();
        }

        public void InputNumber(int number)
        {
            _refresherBoardNumbers.InputNumber(number);
            _checkerError.CheckError();
            _refresherBoardHints.RefreshUserInputHints();
            _checkerEndGame.CheckEndGame();

            RefreshLeftCountNumber();
            SaveGame();
        }

        public void InputHint(int number)
        {
            if (_refresherBoardHints.CanInputHint())
            {
                _refresherBoardHints.InputHint(number);

                RefreshInputHints();
                SaveGame();
            }

            _refresherBoardNumbers.RefreshBoard();
            _refresherBoardNumbers.ShowAllTheSameNumber();
            _checkerError.CheckError();

            RefreshLeftCountNumber();
        }

        public void ClickClear()
        {
            _boardData.SelectedCell.ClearNumber();
            _boardData.SelectedCell.ClearHints();

            _refresherBoardNumbers.RefreshBoard();
            _refresherBoardNumbers.ShowAllTheSameNumber();
            _checkerError.CheckError();

            RefreshLeftCountNumber();
            SaveGame();
        }

        public void RefreshInputHints()
        {
            _input.HintsInCell(_boardData.SelectedCell.GetHints());
        }

        public void AutoHints()
        {
            if (_adsService.HasLoadedRewarded())
            {
                _adsService.ShowRewarded(result =>
                {
                    if (result == AdsResultType.Completed)
                        _refresherBoardHints.AutoSetHints();
                });
            }
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            _saveBoard.Save(playerProgress);
        }

        public void LoadUserData(LastGameData progressLastGameData)
        {
            _loadBoard.LoadUserData(progressLastGameData);

            _refresherBoardNumbers.RefreshBoard();
            _refresherBoardNumbers.ShowAllTheSameNumber();
            _checkerError.CheckError();

            RefreshLeftCountNumber();
        }

        public void UpdateTheme(ThemeConfigData themeConfigData)
        {
            _backgroundGame.color = themeConfigData.BackgroundGameColor;
            _background.color = themeConfigData.BackgroundColor;
        }
        
        private void OnClickCell(CellNumber cellNumber)
        {
            _boardData.SetSelectedCell(cellNumber);

            _checkerError.CheckError();
            _refresherBoardNumbers.RefreshBoard();
            _refresherBoardNumbers.ShowAllTheSameNumber();

            RefreshInputHints();
        }

        private void Subscrible()
        {
            _boardData.BoardList.ForEach(x => x.ClickCell += OnClickCell);
        }

        private void Unsubscrible()
        {
            _boardData.BoardList.ForEach(x => x.ClickCell -= OnClickCell);
        }

        private void SaveGame()
        {
            _saveLoadService.SaveProgress();
        }

        private void RefreshLeftCountNumber()
        {
            for (int number = 1; number <= _boardData.Size; number++)
                _input.RefreshLeftNumber(number, CalculateLeftNumber(number));
        }

        private int CalculateLeftNumber(int number) =>
            _boardData.Size - _boardData.BoardList
                .FindAll(x => x.Number == number && (x.LevelNumber || x.CorrectNumber)).Count;
    }
}