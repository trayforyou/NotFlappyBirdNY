using System;
using UnityEngine;

[RequireComponent(typeof(EnemyAttacker))]
public class Enemy : Collisioner, IPoolInstance, IDamageable
{
    private EnemyAttacker _enemyAttack;
    private bool _isLive = false;

    public event Action<Enemy> BecameUnnecessary;
    public event Action Died;

    private void Awake() =>
        _enemyAttack = GetComponent<EnemyAttacker>();

    private void OnEnable() =>
        _isLive = true;

    private void OnDisable() =>
        _isLive = false;

    public void Hide() =>
        BecameUnnecessary?.Invoke(this);

    public void SetMissilesSpawner(SpawnerMissiles spawner) =>
        _enemyAttack.SetMissilesSpawner(spawner);

    public void TakeDamage()
    {
        if (_isLive)
        {
            _isLive = false;
            Died?.Invoke();
            Hide();
        }
    }
}