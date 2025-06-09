using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _minEnemies = 5;
    [SerializeField] private int _maxEnemies = 25;
    [SerializeField] private float _spawnDelay = 1f;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private int _indexFirstPoint;
    private int _indexCurrentPoint;
    private WaitForSeconds _delay;
    private ObjectPool<Enemy> _enemyPool;
    private Coroutine _coroutine;

    private void Awake()
    {
        _indexFirstPoint = 0;
        _indexCurrentPoint = _indexFirstPoint;
        _delay = new WaitForSeconds(_spawnDelay);

        _enemyPool = new ObjectPool<Enemy>
            (
            createFunc: () => Instantiate(_enemyPrefab),
            actionOnGet: enemy => enemy.gameObject.SetActive(true),
            actionOnRelease: enemy => enemy.gameObject.SetActive(false),
            actionOnDestroy: enemy => Destroy(enemy.gameObject),
            collectionCheck: true,
            defaultCapacity: _minEnemies,
            maxSize: _maxEnemies
            );
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Spawning());
    }

    public void Restart()
    {
        _indexCurrentPoint = _indexFirstPoint;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        Enemy enemy;

        while (enabled)
        {
            yield return _delay;

            enemy = _enemyPool.Get();

            enemy.gameObject.transform.position = _spawnPoints[_indexCurrentPoint].gameObject.transform.position;

            _indexCurrentPoint++;
            _indexCurrentPoint %= _spawnPoints.Count;
            yield return null;
        }
    }
}