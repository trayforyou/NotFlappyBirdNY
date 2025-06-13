using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAttack))]
public class Enemy : Collisioner, IPoolInstance
{
    public event Action<Enemy> BacameUnnecessary;

    public void Hide()
    {
        BacameUnnecessary?.Invoke(this);
    }
}
