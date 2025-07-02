using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private string _jumpValue = "Jump";
    private string _FireValue = "Fire1";

    public event Action Jumped;
    public event Action Attack;

    private void Update()
    {
        if (Input.GetAxis(_jumpValue) > 0)
            Jumped?.Invoke();

        if (Input.GetAxis(_FireValue) > 0)
            Attack?.Invoke();
    }
}