using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAttack))]
[RequireComponent(typeof(PlayerAnimationChanger))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private PlayerAttack _playerAttack;
    private PlayerAnimationChanger _playerAnimationChanger;
    private Vector2 _startPosition;

    public event Action Die;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playerAnimationChanger = GetComponent<PlayerAnimationChanger>();
        _startPosition = transform.position;
    }

    public void Reset()
    {
        transform.position = _startPosition;
        _playerMover.Reset();
        _playerAttack.Reset();
        _playerAnimationChanger.Reset();
    }

    public void Kill() =>
        Die?.Invoke();
}