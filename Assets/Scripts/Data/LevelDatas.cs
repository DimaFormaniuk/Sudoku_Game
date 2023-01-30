using System;
using System.Collections.Generic;
using UI.Menu;

namespace Data
{
    [Serializable]
    public class LevelDatas
    {
        public DifficultyLevelData DifficultyLevelData;

        public LevelDatas()
        {
            DifficultyLevelData = new DifficultyLevelData();
        }

        public bool GetCompletedLevel(DifficultyGame difficultyGame, int index)
        {
            return DifficultyLevelData.GetLevelData(difficultyGame).CompletedLevel.Contains(index);
        }

        public void AddCompleteLevel(DifficultyGame difficultyGame, int index)
        {
            DifficultyLevelData.GetLevelData(difficultyGame).CompletedLevel.Add(index);
        }

        public void CompleteLastGame(LastGameData progressLastGameData)
        {
            AddCompleteLevel(progressLastGameData.DifficultyGame, progressLastGameData.IndexLevel);
        }
    }

    [Serializable]
    public class DifficultyLevelData
    {
        public List<LevelData> LevelData;

        public DifficultyLevelData()
        {
            LevelData = new List<LevelData>()
            {
                new(DifficultyGame.Easy),
                new(DifficultyGame.Medium),
                new(DifficultyGame.Hard)
            };
        }

        public LevelData GetLevelData(DifficultyGame difficultyGame) =>
            LevelData.Find(x => x.DifficultyGame == difficultyGame);
    }

    [Serializable]
    public class LevelData
    {
        public DifficultyGame DifficultyGame;
        public List<int> CompletedLevel;

        public LevelData(DifficultyGame difficultyGame)
        {
            DifficultyGame = difficultyGame;
            CompletedLevel = new List<int>();
        }
    }
}