using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private PlayerMover _playerMover;
    private Vector2 _startPosition;


    public event Action Die;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _startPosition = transform.position;
    }

    public void Reset()
    {
        transform.position = _startPosition;
        _playerMover.Reset();
        _scoreCounter.Reset();
    }

    public void Kill() =>
        Die?.Invoke();
}