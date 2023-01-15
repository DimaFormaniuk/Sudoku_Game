using System;
using CodeBase.UI.SelectLevel;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public int LastSelectLevel;
        public DifficultyGame DifficultyGame;

        public LevelDatas LevelDatas;

        public PlayerProgress()
        {
            LastSelectLevel = 1;
            DifficultyGame = DifficultyGame.Easy;

            LevelDatas = new LevelDatas();
        }
    }
}