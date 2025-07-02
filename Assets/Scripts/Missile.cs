using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Missile : MonoBehaviour, IPoolInstance
{
    [SerializeField] private float _speed = 10;

    private Rigidbody2D _rigidbody;
    private bool _canKill;

    public event Action<Missile> KilledEnemy;
    public event Action<Missile> BecameUnnecessary;

    private void Awake() => 
        _rigidbody = GetComponent<Rigidbody2D>();

    private void OnEnable() => 
        _canKill = true;

    private void OnTriggerEnter2D(Collider2D collision) => 
        TryTakeDamage(collision);

    public void Reset() => 
        _rigidbody.velocity = Vector2.zero;

    public void Hide() => 
        BecameUnnecessary?.Invoke(this);

    public void SetDirection(Vector2 direction) => 
        _rigidbody.velocity = direction * _speed;

    private void TryTakeDamage(Collider2D collision)
    {
        if (_rigidbody.velocity.x < 0 && collision.gameObject.TryGetComponent(out Player player))
        {
            player.Kill();
        }
        else if (_rigidbody.velocity.x > 0 && collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (_canKill)
            {
                enemy.Hide();

                KilledEnemy?.Invoke(this);

                BecameUnnecessary?.Invoke(this);
            }
        }
    }
}