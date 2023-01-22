using System;
using System.Collections.Generic;
using CodeBase.UI.Menu;
using UnityEngine.Serialization;

namespace CodeBase.Data
{
    [Serializable]
    public class LastGameData
    {
        public int IndexLevel;
        public DifficultyGame DifficultyGame;
        [FormerlySerializedAs("UserNumber")] public List<int> UserNumbers;
        public List<HintsData> Hints;

        public LastGameData()
        {
            IndexLevel = 0;
            DifficultyGame = DifficultyGame.Easy;
            UserNumbers = new List<int>();
            Hints = new List<HintsData>();
        }
    }
}