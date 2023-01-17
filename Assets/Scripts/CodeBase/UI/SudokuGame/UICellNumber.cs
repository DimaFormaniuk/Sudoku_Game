using System;
using CodeBase.UI.Services.Theme;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.SudokuGame
{
    public class UICellNumber : MonoBehaviour, IThemeReader
    {
        public int Number { get; private set; }
        public int IndexCell { get; private set; }
        public Vector2Int IndexCellVector { get; private set; }
        public int IndexBlock { get; private set; }

        public event Action<UICellNumber> ClickCell;

        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _numberText;
        [SerializeField] private Image _background;
        [SerializeField] private UIHints _uiHints;

        private bool _looked;
        private ThemeConfigs _themeConfigs;

        private CellStatus _cellStatus;
        
        public void Init(int number, int indexCell, int indexBlock)
        {
            Number = number;
            IndexCell = indexCell;
            IndexBlock = indexBlock;
            IndexCellVector = new Vector2Int((IndexCell - 1) % 9, (indexCell - 1) / 9);

            _cellStatus = CellStatus.Empty;
            
            _looked = Number != 0;
            if (Number == 0)
                _cellStatus = CellStatus.LevelNumber;
            
            RefreshUI();

            _uiHints.Init();
            _uiHints.HideAll();
        }

        public void SetUserNumber(int number)
        {
            if (_looked)
                return;

            _cellStatus = CellStatus.UserNumber;
            Number = number;
            RefreshUI();
        }

        private void RefreshUI()
        {
            _numberText.text = $"{Number}";
            _numberText.gameObject.SetActive(Number != 0);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            ClickCell?.Invoke(this);
            Debug.LogError($"{Number} {IndexCell}");
        }

        public void Unselect()
        {
            _cellStatus = CellStatus.Unselect;
            _background.color = _themeConfigs.BaseCellColor;
        }

        public void Select()
        {
            _cellStatus = CellStatus.Select;
            _background.color = _themeConfigs.SelectCellColor;
        }

        public void SelectorLine()
        {
            _cellStatus = CellStatus.LineSelector;
            _background.color = _themeConfigs.SelectorInLineCellColor;
        }

        public void UpdateTheme(ThemeConfigs themeConfigs)
        {
            _themeConfigs = themeConfigs;

            RefreshUI();
        }
    }
}