using System.Collections.Generic;
using Data;
using Infrastructure.Services.SaveLoad;
using UI.Menu;
using UI.SudokuGame.Board;
using UI.SudokuGame.Input;
using UnityEngine;

namespace UI.SudokuGame
{
    public class SudokuGame : MonoBehaviour, ISavedProgress
    {
        private const string Path = "Levels/Level";
        
        [SerializeField] private GameBoard _gameBoard;
        [SerializeField] private UIInput _uiInput;
        [SerializeField] private UITopPanel _uiTopPanel;

        private LevelMenuData _progressLevelMenuData;
        private LastGameData _progressLastGameData;

        private DifficultyGame _difficultyGame;
        private int _indexLevel;

        public void InitNewGame(LevelMenuData progressLevelMenuData)
        {
            _progressLevelMenuData = progressLevelMenuData;

            _difficultyGame = _progressLevelMenuData.DifficultyGame;
            _indexLevel = _progressLevelMenuData.LastSelectLevel;
        }

        public void InitContinueGame(LastGameData progressLastGameData)
        {
            _progressLastGameData = progressLastGameData;

            _difficultyGame = _progressLastGameData.DifficultyGame;
            _indexLevel = _progressLastGameData.IndexLevel;
        }

        public void NewGame()
        {
            string data = LoadLevel(_difficultyGame, _indexLevel);
            _uiInput.Init(_gameBoard);
            _gameBoard.Init(ParseLevel(data), _uiInput);

            _uiTopPanel.NewGame(_difficultyGame);
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.LastGameData.DifficultyGame = _difficultyGame;
            playerProgress.LastGameData.IndexLevel = _indexLevel;
        }

        public void ContinueGame()
        {
            NewGame();
            _gameBoard.LoadUserData(_progressLastGameData);

            _uiTopPanel.ContinueGame();
        }

        private string LoadLevel(DifficultyGame difficultyGame, int index)
        {
            string path = $"{Path}{difficultyGame.GetDescription()}{index}";
            return ((TextAsset)Resources.Load(path)).text;
        }

        private List<int> ParseLevel(string level)
        {
            List<int> result = new List<int>();
            int count = level.Length;
            for (int i = 0; i < count; i++)
                result.Add(int.Parse(level[i].ToString()));

            return result;
        }
    }
}