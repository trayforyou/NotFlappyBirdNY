using System;
using UnityEngine;

[RequireComponent(typeof(EnemyAttack))]
public class Enemy : Collisioner, IPoolInstance
{
    private EnemyAttack _enemyAttack;

    public event Action<Enemy> BecameUnnecessary;

    private void Awake() => 
        _enemyAttack = GetComponent<EnemyAttack>();

    public void Hide() => 
        BecameUnnecessary?.Invoke(this);

    public void SetMissilesSpawner(SpawnerMissiles spawner) => 
        _enemyAttack.SetMissilesSpawner(spawner);
}
