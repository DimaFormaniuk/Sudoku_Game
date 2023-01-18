using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonNumber : MonoBehaviour
{
    [SerializeField] private Button _button;

    [SerializeField] private TMP_Text _numberText;
    [SerializeField] private TMP_Text _leftCountText;

    public int Number { get; private set; }
    private int _leftNumber;

    public event Action<int> ClickNumber;
    
    public void Init(int number)
    {
        Number = number;
        _leftNumber = 0;
        
        _numberText.text = $"{Number}";

        RefreshUI();
    }
    
    public void RefreshLeftNumber(int count)
    {
        _leftNumber = count;
        RefreshUI();
    }

    private void RefreshUI()
    {
        _leftCountText.text = $"{_leftNumber}";
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
        ClickNumber?.Invoke(Number);
        //Debug.LogError($"{Number}");
    }
}