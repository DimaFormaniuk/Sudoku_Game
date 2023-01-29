using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Logo
{
    public class LogoPanel : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Animation _animation;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClickButton);
        }
    
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClickButton);
        }
    
        private void OnClickButton()
        {
            _animation.Play();
        }
    }
}
