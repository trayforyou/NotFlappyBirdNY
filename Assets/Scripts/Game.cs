using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private SpawnerEnemies _spawnerEnemy;
    [SerializeField] private SpawnerMissiles _spawnerMissiles;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void Start() => 
        ActivateStartScreen();

    private void OnEnable()
    {
        _player.Died += EndGame;
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endScreen.RestartButtonClicked += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _player.Died -= EndGame;
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endScreen.RestartButtonClicked -= OnRestartButtonClick;
    }

    private void ActivateStartScreen()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void EndGame()
    {
        Time.timeScale = 0;
        _endScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        ResetGame();
        Time.timeScale = 1;
    }

    private void ResetGame()
    {
        _player.Reset();
        _scoreCounter.Reset();
        _spawnerEnemy.Reset();
        _spawnerMissiles.Reset();
    }
}