using System;
using UI.Menu;

namespace Data
{
    [Serializable]
    public class LevelMenuData
    {
        public int LastSelectLevel;
        public DifficultyGame DifficultyGame;

        public LevelMenuData()
        {
            LastSelectLevel = 1;
            DifficultyGame = DifficultyGame.Easy;
        }
    }
}