using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _rechargeTime = 1;
    [SerializeField] private SpawnerMissiles _spawnerMissiles;

    public event Action KilledEnemy;

    private PlayerInput _playerInput;
    private Coroutine _coroutine;
    private bool _canShoot;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _canShoot = true;
    }

    private void OnEnable() => 
        _playerInput.Attack += Shoot;

    private void OnDisable()
    {
        _playerInput.Attack -= Shoot;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Reset()
    {
        _canShoot = true;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void Shoot()
    {
        if (_canShoot)
        {
            _coroutine = StartCoroutine(Recharge());

            Missile newMissile = _spawnerMissiles.ShootInEnemy(transform.position);

            newMissile.KilledEnemy += KillEnemy;
        }
    }

    private void KillEnemy(Missile missile)
    {
        missile.KilledEnemy -= KillEnemy;

        KilledEnemy?.Invoke();
    }

    private IEnumerator Recharge()
    {
        WaitForSeconds wait = new WaitForSeconds(_rechargeTime);

        _canShoot = false;

        yield return wait;

        _canShoot = true;
    }
}
