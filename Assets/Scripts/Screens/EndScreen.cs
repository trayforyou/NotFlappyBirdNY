using System;
using TMPro;
using UnityEngine;

public class EndScreen : Window
{
    [SerializeField] TextMeshProUGUI _highRecordText;
    [SerializeField] ScoreCounter _scoreCounter;
    [SerializeField] int _highScore;

    private string _baseHighRecodText;

    public event Action RestartButtonClicked;

    private void OnEnable()
    {
        if (_baseHighRecodText == null)
            _baseHighRecodText = _highRecordText.text;

        _highScore = _scoreCounter.GetHighScore();
        _highRecordText.text = _baseHighRecodText + _highScore;
    }

    protected override void OnButtonClick() => 
        RestartButtonClicked?.Invoke();
}
