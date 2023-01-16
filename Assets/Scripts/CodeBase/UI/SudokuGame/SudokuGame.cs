using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.UI.Menu;
using UnityEngine;

namespace CodeBase.UI.SudokuGame
{
    public class SudokuGame : MonoBehaviour
    {
        private const string Path = "Levels/Level";

        [SerializeField] private UIGameBoard _uiGameBoard;
        [SerializeField] private UIInputNumbers _uiInputNumbers;

        public void NewGame(LevelMenuData progressLevelMenuData)
        {
            string data = LoadLevel(progressLevelMenuData.DifficultyGame, progressLevelMenuData.LastSelectLevel);
            _uiInputNumbers.Init();
            _uiGameBoard.Init(ParseLevel(data), _uiInputNumbers);
        }

        public void ContinueGame(LastGameData progressLastGameData)
        {
            string data = LoadLevel(progressLastGameData.DifficultyGame, progressLastGameData.IndexLevel);
            _uiInputNumbers.Init();
            _uiGameBoard.Init(ParseLevel(data), _uiInputNumbers);
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