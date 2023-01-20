using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.SudokuGame
{
    public class UIHints : MonoBehaviour
    {
        [SerializeField] private List<UIHint> _hints;

        private List<int> _showedHints = new List<int>();

        public void Init()
        {
            InitHints();
        }

        private void InitHints()
        {
            for (int i = 0; i < _hints.Count; i++)
                _hints[i].Init(i + 1);
        }

        public void HideAll()
        {
            for (int i = 0; i < _hints.Count; i++)
                _hints[i].Hide();

            _showedHints = new List<int>();
        }

        public void SetHints(List<int> hints)
        {
            HideAll();

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
    }
}