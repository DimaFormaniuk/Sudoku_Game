using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.SelectLevel
{
    [RequireComponent(typeof(Button))]
    public class UIMenuButton : MonoBehaviour
    {
        [SerializeField] private DifficultyGame _difficultyType;
        public DifficultyGame DifficultyType => _difficultyType;

        [SerializeField] private Button _button;

        public event Action<UIMenuButton> Click;

        private void OnEnable() => 
            _button.onClick.AddListener(ClickCell);

        private void OnDisable() => 
            _button.onClick.RemoveListener(ClickCell);

        private void ClickCell() =>
            Click?.Invoke(this);
    }
}
