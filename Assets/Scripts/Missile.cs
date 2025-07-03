using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Missile : MonoBehaviour, IPoolInstance
{
    [SerializeField] private float _speed = 10;

    private LayerMask _target;
    private Rigidbody2D _rigidbody;

    public event Action<Missile> BecameUnnecessary;

    private void Awake() =>
        _rigidbody = GetComponent<Rigidbody2D>();

    private void OnTriggerEnter2D(Collider2D collision) =>
        TryToDamage(collision);

    public void Reset() =>
        _rigidbody.velocity = Vector2.zero;

    public void Hide() =>
        BecameUnnecessary?.Invoke(this);

    public void SetDirection(Vector2 direction) =>
        _rigidbody.velocity = direction * _speed;

    public void SetTarget(LayerMask target) =>
        _target = target;

    private void TryToDamage(Collider2D collision)
    {
            if (collision.gameObject.TryGetComponent(out IDamageable damageableSubject) && (1 << collision.gameObject.layer) == _target)
            {
                    damageableSubject.TakeDamage();
                    BecameUnnecessary?.Invoke(this);
            }
        }
}