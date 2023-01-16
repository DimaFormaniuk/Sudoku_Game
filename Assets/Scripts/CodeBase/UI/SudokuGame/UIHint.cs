using TMPro;
using UnityEngine;

namespace CodeBase.UI.SudokuGame
{
    public class UIHint : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
    
        public int Number { get; private set; }

        public void Init(int number)
        {
            Number = number;
        }

        public void Hide()
        {
            _text.gameObject.SetActive(false);
        }
    }
}
