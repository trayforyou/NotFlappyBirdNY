using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimationChanger : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string CurrentState = "";
    private string JumpState;
    private string FallState;

    private void Awake()
    {
        JumpState = "Jump";
        FallState = "Fall";

        Fall();
    }

    public void Jump()
    {
        if (CurrentState != JumpState)
            _animator.Play(JumpState);
    }

    public void Fall()
    {
        if (CurrentState != FallState)
            _animator.Play(FallState);
    }
}