using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string HorizontalAxis = "Horizontal";
    public string VerticalAxis = "Vertical";
    public string Jump = "Jump";

    public Vector2 MoveInput { get; private set; }
    public bool JumpInput { get; private set; }

    public void UpdateInput()
    {
        MoveInput = new Vector2(Input.GetAxis(HorizontalAxis), Input.GetAxis(VerticalAxis));

        JumpInput = Input.GetButtonDown(Jump);
    }
}
