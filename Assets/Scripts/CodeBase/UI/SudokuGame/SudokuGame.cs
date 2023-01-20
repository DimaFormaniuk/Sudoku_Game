using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.UI.Menu;
using CodeBase.UI.SudokuGame.Input;
using UnityEngine;

namespace CodeBase.UI.SudokuGame
{
    public class SudokuGame : MonoBehaviour
    {
        private const string Path = "Levels/Level";

        [SerializeField] private UIGameBoard _uiGameBoard;
        [SerializeField] private UIInput _uiInput;

        private LevelMenuData _progressLevelMenuData;
        private LastGameData _progressLastGameData;

        public void InitNewGame(LevelMenuData progressLevelMenuData)
        {
            _progressLevelMenuData = progressLevelMenuData;
        }

        public void InitContinueGame(LastGameData progressLastGameData)
        {
            _progressLastGameData = progressLastGameData;
        }

        public void NewGame()
        {
            string data = LoadLevel(_progressLevelMenuData.DifficultyGame, _progressLevelMenuData.LastSelectLevel);
            _uiInput.Init(_uiGameBoard);
            _uiGameBoard.Init(ParseLevel(data), _uiInput);
        }

        public void ContinueGame()
        {
            string data = LoadLevel(_progressLastGameData.DifficultyGame, _progressLastGameData.IndexLevel);
            _uiInput.Init(_uiGameBoard);
            _uiGameBoard.Init(ParseLevel(data), _uiInput);
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