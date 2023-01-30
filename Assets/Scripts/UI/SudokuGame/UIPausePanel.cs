using TMPro;
using UI.Menu;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SudokuGame
{
    public class UIPausePanel: MonoBehaviour
    {
        [SerializeField] private Button continueButton;

        [SerializeField] private GameObject container;

        [SerializeField] private TMP_Text timeText;
        [SerializeField] private TMP_Text difficultyText;

        private UITimer _uiTimer;

        public void Init(DifficultyGame difficultyGame, UITimer uiTimer)
        {
            difficultyText.text = $"{difficultyGame}";
            _uiTimer = uiTimer;
        }
        
        public void ShowPanel()
        {
            container.SetActive(true);
            
            _uiTimer.PauseTimer();

            timeText.text = _uiTimer.GetTimeText();
        }

        public void HidePanel()
        {
            container.SetActive(false);
            
            _uiTimer.ResumeTimer();
        }

        private void OnEnable()
        {
            continueButton.onClick.AddListener(OnClickContinue);
        }

        private void OnDisable()
        {
            continueButton.onClick.RemoveListener(OnClickContinue);
        }
        
        private void OnClickContinue()
        {
            HidePanel();
        }
    }
}