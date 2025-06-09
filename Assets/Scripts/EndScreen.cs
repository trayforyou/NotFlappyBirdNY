using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : Window
{
    [SerializeField] TextMeshProUGUI _highRecordText;
    [SerializeField] int _highScore;
    [SerializeField] ScoreCounter _scoreCounter;

    private string _baseHighRecodText;

    public event Action RestartButtonClicked;

    private void Awake()
    {
        _baseHighRecodText = _highRecordText.text;

        _scoreCounter.ChangedHighScore += ChangeHighScore;
    }

    private void ChangeHighScore(int highScore)
    {
        _highRecordText.text = _baseHighRecodText + _highScore;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}
