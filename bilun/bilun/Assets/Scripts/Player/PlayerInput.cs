using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public bool JumpInput { get; private set; }

    public void UpdateInput()
    {
        MoveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        JumpInput = Input.GetButtonDown("Jump");
    }
}
