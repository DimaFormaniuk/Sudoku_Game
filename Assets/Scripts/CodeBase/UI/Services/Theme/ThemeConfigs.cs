using System;
using UnityEngine;

namespace CodeBase.UI.Services.Theme
{
    [Serializable]
    public class ThemeConfigs
    {
        [Header("Text colors")]
        public Color LevelNumberTextColor;
        public Color UserTextColor;
        public Color ErrorTextColor;
        
        [Header("Background Cell colors")]
        public Color BaseCellColor;
        public Color SelectCellColor;
        public Color SelectorInLineCellColor;
        public Color CellDeniesUserInputColor;
        
        [Header("Block Lines color")] 
        public Color BlockLinesColor;
        public Color SelectorBlockLinesColor;

        [Header("Inputs")] 
        public Color InputTextColor;
        public Color InputLeftTextColor;
        public Color InputBackgroundColor;
        [Space]
        public Color EnableHintTextColor;
        public Color EnableHintBackgroundColor;
        public Color DisableHintTextColor;
        public Color DisableHintBackgroundColor;
    }
}