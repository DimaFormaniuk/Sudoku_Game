using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Menu
{
    [RequireComponent(typeof(Button))]
    public class UICellButton : MonoBehaviour
    {
        public event Action<UICellButton> Click;
        public int Index { get; private set; }

        private bool _completed;

        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;


        public void Init(int index, bool completed)
        {
            Index = index;
            _completed = completed;

            Refresh();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(ClickCell);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ClickCell);
        }

        private void ClickCell() =>
            Click?.Invoke(this);

        public void Refresh()
        {
            _text.text = Index.ToString();
        
        
        }
    }
}