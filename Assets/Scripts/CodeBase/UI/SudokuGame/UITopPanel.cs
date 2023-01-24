using CodeBase.UI.Menu;
using CodeBase.UI.SudokuGame.ThemePanel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.SudokuGame
{
    public class UITopPanel : MonoBehaviour
    {
        [SerializeField] private Button _themeButton;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _closeButton;

        [SerializeField] private TMP_Text _difficultyText;

        [SerializeField] private UIThemePanel _uiThemePanel;
        [SerializeField] private UITimer _uiTimer;
        [SerializeField] private UIPausePanel _uiPausePanel;

        public void NewGame(DifficultyGame difficultyGame)
        {
            _uiThemePanel.Init();
            _uiTimer.StartTimer();
            _difficultyText.text = $"{difficultyGame}";
        }

        public void ContinueGame()
        {
            _uiTimer.LoadTimer();
        }

        private void OnEnable()
        {
            _themeButton.onClick.AddListener(OnClickThemeButton);
            _pauseButton.onClick.AddListener(OnClickThemeButton);
        }

        private void OnDisable()
        {
            _themeButton.onClick.RemoveListener(OnClickThemeButton);
            _pauseButton.onClick.RemoveListener(OnClickThemeButton);
        }

        private void OnClickThemeButton()
        {
            _uiThemePanel.ShowPanel();
        }
    }
}