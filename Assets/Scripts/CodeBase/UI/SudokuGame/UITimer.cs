using System;
using System.Collections;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.SaveLoad;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.SudokuGame
{
    public class UITimer : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private TMP_Text timerText;

        private TimeSpan _time;
        private PlayerProgress _playerProgress;

        private Coroutine _timerCoroutine;

        public void StartTimer()
        {
            _time = new TimeSpan(0);
            
            PauseTimer();
            ResumeTimer();
        }

        public void PauseTimer()
        {
            if (_timerCoroutine != null)
                StopCoroutine(_timerCoroutine);
        }

        public void ResumeTimer()
        {
            _timerCoroutine = StartCoroutine(TimerCoroutine());
        }

        public void LoadTimer()
        {
            _time = new TimeSpan(_playerProgress.LastGameData.Time);
            
            PauseTimer();
            ResumeTimer();
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            _playerProgress = playerProgress;
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.LastGameData.Time = _time.Ticks;
        }

        private void OnDestroy()
        {
            if (_timerCoroutine != null)
                StopCoroutine(_timerCoroutine);
        }

        private IEnumerator TimerCoroutine()
        {
            RefreshUI();
            
            while (true)
            {
                yield return new WaitForSeconds(1f);
                
                _time = _time.Add(new TimeSpan(TimeSpan.TicksPerSecond));
                RefreshUI();
            }
        }
        
        private void RefreshUI()
        {
            timerText.text = _time.ToString(_time.Hours > 0 ? @"hh\:mm\:ss" : @"mm\:ss");
        }
    }
}