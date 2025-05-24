using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private ScoreCounter _scoreCounter;
    private PlayerCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<PlayerCollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Ground)
        {
            Debug.Log("Бубадуба");
            GameOver?.Invoke();
        }
    }

    public void Restart()
    {
        
    }

    internal void Reset()
    {
        _playerMover.Reset();
        _scoreCounter.Reset();
    }
}