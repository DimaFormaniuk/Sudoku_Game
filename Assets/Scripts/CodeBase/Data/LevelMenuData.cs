using System;
using CodeBase.UI.Menu;

namespace CodeBase.Data
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