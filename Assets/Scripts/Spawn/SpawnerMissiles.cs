using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerMissiles : MonoBehaviour
{
    //[SerializeField] private Missile _missilePrefab;

    //private ObjectPool<Enemy> _missilesPool;
    //private int _maxMissiles;
    //private int _minMissiles;
    //private Coroutine _coroutine;
    //private List<Missile> _missileInstances;

    //private void Awake()
    //{
    //    _missilesPool = new ObjectPool<Enemy>
    //        (
    //        createFunc: () => InstantiateInstance(),
    //        actionOnGet: missile => CreateEnemy(missile),
    //        actionOnRelease: missile => ReleaceEnemy(missile),
    //        actionOnDestroy: missile => DestroyInstance(missile),
    //        collectionCheck: true,
    //        defaultCapacity: _minMissiles,
    //        maxSize: _maxMissiles
    //        );
    //}

    //private Enemy InstantiateInstance()
    //{
    //    Missile missile = Instantiate(_missilePrefab);

    //    _enemyInstances.Add(enemy);

    //    return enemy;
    //}

    //private void DestroyInstance(Enemy enemy)
    //{
    //    _enemyInstances.Remove(enemy);

    //    Destroy(enemy.gameObject);
    //}

    //private void CreateEnemy(Enemy enemy)
    //{
    //    enemy.transform.position = Vector2.zero;

    //    enemy.BacameUnnecessary += _enemyPool.Release;

    //    enemy.gameObject.SetActive(true);

    //}

    //private void ReleaceEnemy(Enemy enemy)
    //{
    //    enemy.BacameUnnecessary -= _enemyPool.Release;

    //    enemy.gameObject.SetActive(false);
    //}

    //public void Reset()
    //{
    //    for (int i = 0; i < _enemyInstances.Count; i++)
    //    {
    //        if (_enemyInstances[i].isActiveAndEnabled)
    //            _enemyPool.Release(_enemyInstances[i]);

    //        Debug.Log("Ubral");
    //    }

    //    _indexCurrentPoint = _indexFirstPoint;

    //    if (_coroutine != null)
    //        StopCoroutine(_coroutine);

    //    _coroutine = StartCoroutine(Spawning());
    //}
}
