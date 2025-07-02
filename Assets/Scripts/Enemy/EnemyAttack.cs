using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private SpawnerMissiles _missleSpawner;
    [SerializeField] private float _delayAttack;

    private Coroutine _coroutine;

    private void OnEnable() => 
        _coroutine = StartCoroutine(StartShooting());

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void SetMissilesSpawner(SpawnerMissiles spawner) =>
        _missleSpawner = spawner;

    private IEnumerator StartShooting()
    {
        WaitForSeconds wait = new WaitForSeconds(_delayAttack);

        while (enabled)
        {
            yield return wait;

            _missleSpawner.ShootInPlayer(transform.position);
        }
    }
}