using System.Collections.Generic;
using Infrastructure.Services.Theme;
using UnityEngine;

namespace UI.SudokuGame.Hint
{
    public class UIHints : MonoBehaviour, IThemeReader
    {
        [SerializeField] private List<UIHint> _hints;
        [SerializeField] private Animation _deniesForHint;

        private List<int> _showedHints = new List<int>();

        public void Init(bool levelNumber)
        {
            for (int i = 0; i < _hints.Count; i++)
                _hints[i].Init(i + 1);
        }

        public void SetHints(List<int> hints)
        {
            ClearHints();

            foreach (var index in hints)
                _hints[index - 1].Show();

            _showedHints = hints;
        }

        public void SetUserHint(int number)
        {
            if (_showedHints.Contains(number))
            {
                _showedHints.Remove(number);
                _hints[number - 1].Hide();
            }
            else
            {
                _showedHints.Add(number);
                _hints[number - 1].Show();
            }
        }

        public List<int> GetHints()
        {
            return _showedHints;
        }

        public void UpdateTheme(ThemeConfigData themeConfigData)
        {
            foreach (var uiHint in _hints)
                uiHint.RefreshColor(themeConfigData.HintColor);
        }

        public void ShowDeniesForHints()
        {
            _deniesForHint.Play();
        }

        public void ClearHints()
        {
            for (int i = 0; i < _hints.Count; i++)
                _hints[i].Hide();

            _showedHints = new List<int>();
        }
    }
}