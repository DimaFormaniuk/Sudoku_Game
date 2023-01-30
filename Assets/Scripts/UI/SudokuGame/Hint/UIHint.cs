using TMPro;
using UnityEngine;

namespace UI.SudokuGame.Hint
{
    public class UIHint : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
    
        public int Number { get; private set; }

        public void Init(int number)
        {
            Number = number;

            RefreshUI();
        }

        public void Hide()
        {
            _text.gameObject.SetActive(false);
        }

        public void Show()
        {
            _text.gameObject.SetActive(true);
        }

        public void RefreshColor(Color hintColor)
        {
            _text.color = hintColor;
        }
        
        private void RefreshUI()
        {
            _text.text = $"{Number}";
        }
    }
}
