using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private LayerMask _target;
    [SerializeField] private float _rechargeTime = 1;
    [SerializeField] private SpawnerMissiles _spawnerMissiles;

    private PlayerInput _playerInput;
    private Coroutine _coroutine;
    private bool _canShoot;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _canShoot = true;
    }

    private void OnEnable() => 
        _playerInput.AttackButtonPressed += Shoot;

    private void OnDisable()
    {
        _playerInput.AttackButtonPressed -= Shoot;

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

            _spawnerMissiles.Shoot(transform.position, Vector2.right, _target);
        }
    }

    private IEnumerator Recharge()
    {
        WaitForSeconds wait = new WaitForSeconds(_rechargeTime);

        _canShoot = false;

        yield return wait;

        _canShoot = true;
    }
}
