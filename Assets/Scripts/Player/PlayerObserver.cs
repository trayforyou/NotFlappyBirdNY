using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _xOffset;

    private void FixedUpdate()
    {
        var position = transform.position;
        position.x = _player.transform.position.x + _xOffset;
        transform.position = position; 
    }
}