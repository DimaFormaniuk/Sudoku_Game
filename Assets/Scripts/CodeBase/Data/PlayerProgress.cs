using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public LevelMenuData LevelMenuData;
        public LastGameData LastGameData;
        public LevelDatas LevelDatas;
        public ThemeData ThemeData;
        
        public PlayerProgress()
        {
            LevelMenuData = new LevelMenuData();
            LastGameData = new LastGameData();
            LevelDatas = new LevelDatas();
            ThemeData = new ThemeData();
        }
    }
}