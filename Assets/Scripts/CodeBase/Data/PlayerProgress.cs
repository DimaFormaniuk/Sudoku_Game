using System;
using System.Collections.Generic;
using CodeBase.UI.SelectLevel;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public LevelDatas LevelDatas;
    }

    [Serializable]
    public class LevelDatas
    {
        public List<int> dd;
        
        public bool GetData(int index, DifficultyGame difficultyGame)
        {
            return true;
        }
    }
}