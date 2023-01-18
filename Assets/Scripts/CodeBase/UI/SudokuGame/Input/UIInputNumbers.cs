using System;
using System.Collections.Generic;
using UnityEngine;

public class UIInputNumbers : MonoBehaviour
{
    public event Action<int> ClickNumber;

    public List<UIButtonNumber> UIButtonNumbers => _uiButtonNumbers;
    [SerializeField] private List<UIButtonNumber> _uiButtonNumbers;

    public void Init()
    {
        InitButtons();
        Subscrible();
    }

    private void OnDestroy()
    {
        Unsubscrible();
    }

    private void InitButtons()
    {
        for (var i = 0; i < _uiButtonNumbers.Count; i++)
            _uiButtonNumbers[i].Init(i + 1);
    }

    private void Subscrible()
    {
        for (var i = 0; i < _uiButtonNumbers.Count; i++)
            _uiButtonNumbers[i].ClickNumber += OnClickNumber;
    }

    private void Unsubscrible()
    {
        for (var i = 0; i < _uiButtonNumbers.Count; i++)
            _uiButtonNumbers[i].ClickNumber -= OnClickNumber;
    }

    private void OnClickNumber(int number)
    {
        ClickNumber?.Invoke(number);
    }
}