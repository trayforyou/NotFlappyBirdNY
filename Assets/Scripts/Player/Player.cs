using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAttacker))]
[RequireComponent(typeof(PlayerAnimationChanger))]
public class Player : MonoBehaviour, IDamageable
{
    private PlayerMover _playerMover;
    private PlayerAttacker _playerAttack;
    private PlayerAnimationChanger _playerAnimationChanger;
    private Vector2 _startPosition;

    public event Action Died;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerAttack = GetComponent<PlayerAttacker>();
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

    public void TakeDamage() => 
        Died?.Invoke();
}