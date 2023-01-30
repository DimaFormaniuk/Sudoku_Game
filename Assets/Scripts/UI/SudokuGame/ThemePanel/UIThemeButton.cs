using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SudokuGame.ThemePanel
{
    public class UIThemeButton : MonoBehaviour
    {
        public int Index => _index;
        public Action<UIThemeButton> ClickButton = null;
        
        [SerializeField] private Button button;
        [SerializeField] private Image backgroundImage;
        
        private int _index;

        public void Init(int index, Color mainColor)
        {
            _index = index;
            backgroundImage.color = mainColor;
        }

        private void OnEnable()
        {
            button.onClick.AddListener(OnClickButton);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(OnClickButton);
        }

        private void OnClickButton()
        {
            ClickButton?.Invoke(this);
        }
    }
}