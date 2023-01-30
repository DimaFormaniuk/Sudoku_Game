using System.Collections.Generic;
using Infrastructure.Services.Theme;
using TMPro;
using UI.Menu;
using UI.SudokuGame.ThemePanel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SudokuGame
{
    public class UITopPanel : MonoBehaviour,IThemeReader
    {
        [SerializeField] private Button _themeButton;
        [SerializeField] private Button _pauseButton;

        [SerializeField] private List<Image> _iconsList;

        [SerializeField] private TMP_Text _difficultyText;

        [SerializeField] private UIThemePanel _uiThemePanel;
        [SerializeField] private UITimer _uiTimer;
        [SerializeField] private UIPausePanel _uiPausePanel;
        
        private ThemeConfigData _themeConfigData;

        public void NewGame(DifficultyGame difficultyGame)
        {
            _uiThemePanel.Init();
            _uiPausePanel.Init(difficultyGame,_uiTimer);
            _uiTimer.StartTimer();
            _difficultyText.text = $"{difficultyGame}";
        }

        public void ContinueGame()
        {
            _uiTimer.LoadTimer();
        }

        private void OnEnable()
        {
            _themeButton.onClick.AddListener(OnClickTheme);
            _pauseButton.onClick.AddListener(OnClickPause);
        }

        private void OnDisable()
        {
            _themeButton.onClick.RemoveListener(OnClickTheme);
            _pauseButton.onClick.RemoveListener(OnClickPause);
        }

        private void OnClickTheme()
        {
            _uiThemePanel.ShowPanel();
        }
        
        private void OnClickPause()
        {
            _uiPausePanel.ShowPanel();
        }

        public void UpdateTheme(ThemeConfigData themeConfigData)
        {
            _themeConfigData = themeConfigData;
            
            foreach (var image in _iconsList)
                image.color = _themeConfigData.InputLeftTextColor;
            
            _difficultyText.color= _themeConfigData.InputLeftTextColor;
        }
    }
}