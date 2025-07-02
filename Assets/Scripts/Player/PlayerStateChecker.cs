using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAnimationChanger))]
public class PlayerStateChecker : MonoBehaviour
{
    private PlayerAnimationChanger _animationChanger;
    private Rigidbody2D _rigidbody;
    private bool _isFall;

    private void Awake()
    {
        _animationChanger = GetComponent<PlayerAnimationChanger>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _isFall = false;
    }

    private void Start() => 
        StartCoroutine(GetState());

    private IEnumerator GetState()
    {
        while (enabled)
        {
            if (_rigidbody.velocity.y < 0 && !_isFall)
            {
                _isFall = true;
                _animationChanger.Fall();
            }
            else if (_rigidbody.velocity.y > 0 && _isFall)
            {
                _isFall = false;
                _animationChanger.Jump();
            }

            yield return null;
        }
    }
}