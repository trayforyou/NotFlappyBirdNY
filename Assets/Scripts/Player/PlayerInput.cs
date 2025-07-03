using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private string _jumpValue = "Jump";
    private string _fireValue = "Fire1";

    public event Action JumpButtonPressed;
    public event Action AttackButtonPressed;

    private void Update()
    {
        if (Input.GetAxis(_jumpValue) > 0)
            JumpButtonPressed?.Invoke();

        if (Input.GetAxis(_fireValue) > 0)
            AttackButtonPressed?.Invoke();
    }
}