using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimationChanger : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _currentState;
    private int _jumpState;
    private int _fallState;

    private void Awake()
    {
        _currentState = 0;
        _jumpState = PlayerAnimatorData.Params.Jump;
        _fallState = PlayerAnimatorData.Params.Fall;
    }

    public void Jump()
    {
        if (_currentState != _jumpState)
        {
            _currentState = _jumpState;
            _animator.Play(_jumpState);
        }
    }

    public void Fall()
    {
        if (_currentState != _fallState)
        {
            _currentState = _fallState;
            _animator.Play(_fallState);
        }
    }

    public void Reset() => 
        Fall();
}