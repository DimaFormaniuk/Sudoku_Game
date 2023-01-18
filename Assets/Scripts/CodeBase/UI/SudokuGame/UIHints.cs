using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.SudokuGame
{
    public class UIHints : MonoBehaviour
    {
        [SerializeField] private List<UIHint> _hints;

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
        }
        
        public void SetHints(List<int> hints)
        {
            HideAll();

            foreach (var index in hints)
                _hints[index - 1].Show();
        }
    }
}
