using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1;
    [SerializeField] private float _speed = 1;

    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start() => 
        StartCoroutine(MoveFoward());

    private void OnEnable() => 
        _playerInput.JumpButtonPressed += Jump;

    private void OnDisable() => 
        _playerInput.JumpButtonPressed -= Jump;

    public void Reset() => 
        _rigidbody.velocity = Vector2.zero;

    private void Jump()
    {
        Vector2 velocity = _rigidbody.velocity;
        velocity.y = _jumpForce;
        _rigidbody.velocity = velocity;
    }

    private IEnumerator MoveFoward()
    {
        while (enabled)
        {
            Vector2 velocity = _rigidbody.velocity;
            velocity.x = _speed;
            _rigidbody.velocity = velocity;

            yield return null;
        }
    }
}