using System;
using System.Collections.Generic;
using CodeBase.UI.Menu;

namespace CodeBase.Data
{
    [Serializable]
    public class LevelDatas
    {
        public Dictionary<DifficultyGame, List<int>> CompletedLevel;

        public LevelDatas()
        {
            CompletedLevel = new Dictionary<DifficultyGame, List<int>>();
        }

        public bool GetData(DifficultyGame difficultyGame, int index)
        {
            if (CompletedLevel.ContainsKey(difficultyGame))
                return CompletedLevel[difficultyGame].Contains(index);

            return false;
        }

        public void AddCompleteLevel(DifficultyGame difficultyGame, int index)
        {
            if (CompletedLevel.ContainsKey(difficultyGame))
                CompletedLevel[difficultyGame].Add(index);
            else
                CompletedLevel.Add(difficultyGame, new List<int> { index });
        }

        public void CompleteLastGame(LastGameData progressLastGameData)
        {
            AddCompleteLevel(progressLastGameData.DifficultyGame, progressLastGameData.IndexLevel);
        }
    }
}