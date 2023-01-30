using System;
using System.Collections.Generic;
using UI.Menu;

namespace Data
{
    [Serializable]
    public class LastGameData
    {
        public int IndexLevel;
        public DifficultyGame DifficultyGame;
        public long Time;
        public List<int> UserNumbers;
        public List<HintsData> Hints;

        public LastGameData()
        {
            IndexLevel = 0;
            DifficultyGame = DifficultyGame.Easy;
            Time = 0;
            UserNumbers = new List<int>();
            Hints = new List<HintsData>();
        }
    }
}