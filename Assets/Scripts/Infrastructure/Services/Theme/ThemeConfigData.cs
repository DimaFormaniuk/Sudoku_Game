using UnityEngine;

namespace Infrastructure.Services.Theme
{
    [CreateAssetMenu(menuName = "Static Data/Theme Config Data", fileName = "ThemeConfigData")]
    public class ThemeConfigData : ScriptableObject
    {
        [Header("Settings")] 
        public Color MainColor;
        public Color BackgroundColor;
        public Color BackgroundGameColor;
        public Color SelectorColor;

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

        [Header("Inputs")] 
        public Color InputTextColor;
        public Color InputLeftTextColor;
        public Color InputBackgroundColor;
        
        [Space] 
        public Color EnableHintTextColor;
        public Color EnableHintBackgroundColor;
        public Color DisableHintTextColor;
        public Color DisableHintBackgroundColor;

        [Header("Hints")] 
        public Color HintColor;
    }
}