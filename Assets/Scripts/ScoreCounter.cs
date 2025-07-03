using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentCount;
    [SerializeField] private SpawnerEnemies _spawnerEnemies;
    [SerializeField] private int _murderPoints = 10;

    private string _text;
    private int _highScore;
    private int _currentScore = 0;
    private Coroutine _coroutine;

    public event Action<int> ChangedHighScore;

    private void Awake() =>
        _text = _currentCount.text;

    private void Start()
    {
        _coroutine = StartCoroutine(StartCounting());
        ChangedHighScore?.Invoke(_currentScore);
    }

    private void OnEnable() =>
        _spawnerEnemies.EnemyDied += UpScore;

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _spawnerEnemies.EnemyDied -= UpScore;
    }

    public void Reset() =>
    _currentScore = 0;

    public int GetHighScore() =>
        _highScore;

    private void UpScore() => 
        _currentScore += _murderPoints;

    private IEnumerator StartCounting()
    {
        float delay = 0.5f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (enabled)
        {
            _currentCount.text = _text + _currentScore;

            if (_highScore < _currentScore)
            {
                _highScore = _currentScore;

                ChangedHighScore?.Invoke(_highScore);
            }

            yield return wait;

            _currentScore++;
        }
    }
}