using Data;
using Infrastructure.Services.SaveLoad;
using TMPro;
using UnityEngine;

namespace UI.EndGame
{
    public class EndGameInformationPanel : MonoBehaviour,ISavedProgressReader
    {
        [SerializeField] private TMP_Text difficultText;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private TMP_Text timeText;
        
        public void LoadProgress(PlayerProgress playerProgress)
        {
            difficultText.text = $"{playerProgress.LastGameData.DifficultyGame}";
            levelText.text = $"{playerProgress.LastGameData.IndexLevel}";
            timeText.text = $"{playerProgress.LastGameData.Time.ConvertToTime()}";
        }
    }
}
