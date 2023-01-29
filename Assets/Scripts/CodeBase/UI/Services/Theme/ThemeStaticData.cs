using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.Services.Theme
{
    [CreateAssetMenu(menuName = "Static Data/Theme static data", fileName = "ThemeStaticData")]
    public class ThemeStaticData : ScriptableObject
    {
        public MainThemeConfigData mainThemeConfigData;
        public List<ThemeConfigData> configs;
    }
}