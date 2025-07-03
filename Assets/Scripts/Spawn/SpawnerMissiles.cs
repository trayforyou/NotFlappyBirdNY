using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerMissiles : MonoBehaviour
{
    [SerializeField] private int _maxPool;
    [SerializeField] private int _minPool;
    [SerializeField] private Missile _missilePrefab;

    private ObjectPool<Missile> _missilesPool;
    private List<Missile> _missilesInstances = new List<Missile>();

    private void Awake()
    {
        _missilesPool = new ObjectPool<Missile>
            (
            createFunc: () => InstantiateMissile(),
            actionOnGet: missile => missile.gameObject.SetActive(true),
            actionOnRelease: missile => ReleaceMissile(missile),
            actionOnDestroy: missile => DestroyMissile(missile),
            collectionCheck: true,
            defaultCapacity: _minPool,
            maxSize: _maxPool
            );
    }

    public void Reset()
    {
        for (int i = 0; i < _missilesInstances.Count; i++)
        {
            if (_missilesInstances[i].isActiveAndEnabled)
                _missilesPool.Release(_missilesInstances[i]);
        }
    }

    public void Shoot(Vector2 position, Vector2 direction, LayerMask target)
    {
        Missile missile = _missilesPool.Get();
        missile.BecameUnnecessary += _missilesPool.Release;
        missile.transform.position = position;
        missile.SetDirection(direction);
        missile.SetTarget(target);
    }

    private void ReleaceMissile(Missile missile)
    {
        missile.gameObject.SetActive(false);
        missile.BecameUnnecessary -= _missilesPool.Release;
        missile.Reset();
    }

    private void DestroyMissile(Missile missile)
    {
        _missilesInstances.Remove(missile);
        Destroy(missile.gameObject);
    }

    private Missile InstantiateMissile()
    {
        Missile missile = Instantiate(_missilePrefab);
        _missilesInstances.Add(missile);

        return missile;
    }
}