using System;
using UnityEngine;

namespace CodeBase.UI.Services.Theme
{
    [Serializable]
    public class MainThemeConfigData
    {
        [Header("Grid Select Level")]
        public Color BaseLevelColor;
        public Color CompletedLevelColor;
        public Color SavedLevelColor;
        
        [Header("Select Level Difficulty")] 
        public Color BaseDifficultyColor;
        public Color SelectDifficultyColor;
    }
}