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

        public bool GetData(int index, DifficultyGame difficultyGame)
        {
            if (CompletedLevel.ContainsKey(difficultyGame))
                return CompletedLevel[difficultyGame].Contains(index);

            return false;
        }
    }
}