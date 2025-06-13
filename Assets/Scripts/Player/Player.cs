using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    

    private PlayerMover _playerMover;
    private Vector2 _startPosition;


    public event Action Die;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _startPosition = transform.position;
    }

    public void Reset()
    {
        transform.position = _startPosition;
        Debug.Log("Reeset Position");
        _playerMover.Reset();
    }

    public void Kill() =>
        Die?.Invoke();
}