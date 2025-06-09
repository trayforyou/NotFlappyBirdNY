using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _currentCount;

    private string _text;
    private int _highScore;
    private int _currentScore = 0;
    private Coroutine _coroutine;

    public event Action<int> ChangedCurrentScore;
    public event Action<int> ChangedHighScore;

    private void Awake()
    {
        _text = _currentCount.text;
    }

    private void Start()
    {
        _coroutine = StartCoroutine(StartCounting());

        ChangedHighScore?.Invoke(_currentScore);
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public int GetHighScore()
        => _highScore;

    public void Reset()
    {
        _currentScore = 0;
    }

    private IEnumerator StartCounting()
    {
        float delay = 0.5f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while(enabled)
        {
            _currentCount.text = _text + _currentScore;

            if(_highScore < _currentScore)
            {
                _highScore = _currentScore;

                ChangedHighScore?.Invoke(_highScore);
            }

            yield return wait;

            _currentScore++;
        }
    }
}
