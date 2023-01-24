using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.UI.Services.Theme;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.SudokuGame.ThemePanel
{
    public class UIThemePanel : MonoBehaviour, IThemeReader, ISavedProgressReader
    {
        [SerializeField] private GameObject container;
        [SerializeField] private Button closeButton;
        [SerializeField] private List<UIThemeButton> uiThemeButtons;
        [SerializeField] private Image selectorThemeButtons;

        private ThemeConfigData _themeConfigData;

        private int _indexSelector = 0;

        private IThemeService _themeService;
        private ISaveLoadService _saveLoadService;

        public void Init()
        {
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
            _themeService = AllServices.Container.Single<IThemeService>();

            for (var i = 0; i < uiThemeButtons.Count; i++)
                uiThemeButtons[i].Init(i, _themeService.ListThemeConfigs[i].MainColor);

            RefreshSelector();
        }

        public void UpdateTheme(ThemeConfigData themeConfigData)
        {
            _themeConfigData = themeConfigData;
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            _indexSelector = playerProgress.ThemeData.IndexTheme;
        }

        public void ShowPanel()
        {
            container.SetActive(true);
        }

        public void HidePanel()
        {
            container.SetActive(false);
        }

        private void OnEnable()
        {
            closeButton.onClick.AddListener(HidePanel);
            uiThemeButtons.ForEach(x => x.ClickButton += OnClickThemeButton);
        }

        private void OnDisable()
        {
            closeButton.onClick.RemoveListener(HidePanel);
            uiThemeButtons.ForEach(x => x.ClickButton -= OnClickThemeButton);
        }

        private void OnClickThemeButton(UIThemeButton button)
        {
            _indexSelector = button.Index;
            _themeService.ChangeTheme(_indexSelector);
            
            RefreshSelector(button);

            _saveLoadService.SaveProgress();
        }

        private void RefreshSelector()
        {
            RefreshSelector(uiThemeButtons.Find(x => x.Index == _indexSelector));
        }
        
        private void RefreshSelector(UIThemeButton button)
        {
            selectorThemeButtons.transform.SetParent(button.transform, false);
            selectorThemeButtons.color = _themeConfigData.SelectorColor;
            selectorThemeButtons.transform.SetAsFirstSibling();
        }
    }
}