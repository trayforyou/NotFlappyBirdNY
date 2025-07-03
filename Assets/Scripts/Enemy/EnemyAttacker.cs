using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private SpawnerMissiles _missleSpawner;
    [SerializeField] private LayerMask _target;
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

            _missleSpawner.Shoot(transform.position, Vector2.left,_target);
        }
    }
}