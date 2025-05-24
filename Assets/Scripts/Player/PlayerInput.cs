using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action Jumped;

    private void Update()
    {
        if (Input.GetAxis("Jump") > 0)
            Jumped?.Invoke();
    }
}