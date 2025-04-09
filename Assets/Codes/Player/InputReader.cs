using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private PlayerController _player;

    private void Awake()
    {
        _player = GetComponent<PlayerController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var _newDirection = context.ReadValue<Vector2>();
        _player.SetDirection(_newDirection);
    }

    public void OnPunch(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _player.Punch();
        }
    }
}
