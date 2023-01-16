using System;
using CodeBase.UI.Menu;

namespace CodeBase.Data
{
    [Serializable]
    public class LastGameData
    {
        public int IndexLevel;
        public DifficultyGame DifficultyGame;
        public LastGameData()
        {
            IndexLevel = 0;
            DifficultyGame = DifficultyGame.Easy;
        }
    }
}