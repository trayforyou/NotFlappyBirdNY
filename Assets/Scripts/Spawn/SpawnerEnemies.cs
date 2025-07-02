using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _minEnemies = 5;
    [SerializeField] private int _maxEnemies = 25;
    [SerializeField] private float _spawnDelay = 1;
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private SpawnerMissiles _spawnerMissiles;

    private int _indexFirstPoint;
    private int _indexCurrentPoint;
    private WaitForSeconds _delay;
    private ObjectPool<Enemy> _enemyPool;
    private Coroutine _coroutine;
    private List<Enemy> _enemyInstances = new List<Enemy>();

    private void Awake()
    {
        _indexFirstPoint = 0;
        _indexCurrentPoint = _indexFirstPoint;
        _delay = new WaitForSeconds(_spawnDelay);

        _enemyPool = new ObjectPool<Enemy>
            (
            createFunc: () => InstantiateInstance(),
            actionOnGet: enemy => CreateEnemy(enemy),
            actionOnRelease: enemy => ReleaceEnemy(enemy),
            actionOnDestroy: enemy => DestroyInstance(enemy
            ),
            collectionCheck: true,
            defaultCapacity: _minEnemies,
            maxSize: _maxEnemies
            );
    }

    private void Start() => 
        _coroutine = StartCoroutine(Spawning());

    public void Reset()
    {
        for (int i = 0; i < _enemyInstances.Count; i++)
        {
            if (_enemyInstances[i].isActiveAndEnabled)
                _enemyPool.Release(_enemyInstances[i]);
        }

        _indexCurrentPoint = _indexFirstPoint;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Spawning());
    }

    private Enemy InstantiateInstance()
    {
        Enemy enemy = Instantiate(_enemyPrefab);
        enemy.SetMissilesSpawner(_spawnerMissiles);
        _enemyInstances.Add(enemy);

        return enemy;
    }

    private void DestroyInstance(Enemy enemy)
    {
        _enemyInstances.Remove(enemy);
        Destroy(enemy.gameObject);
    }

    private void CreateEnemy(Enemy enemy)
    {
        enemy.transform.position = Vector2.zero;
        enemy.BecameUnnecessary += _enemyPool.Release;
        enemy.gameObject.SetActive(true);
    }

    private void ReleaceEnemy(Enemy enemy)
    {
        enemy.BecameUnnecessary -= _enemyPool.Release;
        enemy.gameObject.SetActive(false);
    }

    private IEnumerator Spawning()
    {
        Enemy enemy;

        while (enabled)
        {
            yield return _delay;

            enemy = _enemyPool.Get();
            enemy.transform.position = _spawnPoints[_indexCurrentPoint].transform.position;
            _indexCurrentPoint = Random.Range(0,_spawnPoints.Count);

            yield return null;
        }
    }
}