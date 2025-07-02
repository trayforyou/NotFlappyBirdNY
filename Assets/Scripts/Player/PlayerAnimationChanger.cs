using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimationChanger : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _currentState;
    private string _jumpState;
    private string _fallState;

    private void Awake()
    {
        _currentState = "";
        _jumpState = "Jump";
        _fallState = "Fall";
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