using System;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.SaveLoad;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Menu
{
    [RequireComponent(typeof(Button))]
    public class UIDifficultyButton : MonoBehaviour, ISavedProgressReader
    {
        public DifficultyGame DifficultyType => _difficultyType;
        public event Action<UIDifficultyButton> Click;

        [SerializeField] private DifficultyGame _difficultyType;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _informationText;

        public void LoadProgress(PlayerProgress playerProgress)
        {
            int count = playerProgress.LevelDatas.DifficultyLevelData.GetLevelData(_difficultyType).CompletedLevel.Count;

            if (count > 0)
            {
                _informationText.gameObject.SetActive(true);
                _informationText.text = $"{count}/{Constants.LevelCount}";
            }
            else
            {
                _informationText.gameObject.SetActive(false);
            }
        }

        private void OnEnable() =>
            _button.onClick.AddListener(ClickCell);

        private void OnDisable() =>
            _button.onClick.RemoveListener(ClickCell);

        private void ClickCell() =>
            Click?.Invoke(this);
    }
}