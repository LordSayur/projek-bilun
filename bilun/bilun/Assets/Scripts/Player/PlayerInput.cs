using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public int playerNumber = 1;
    public string HorizontalAxis = "Horizontal";
    public string VerticalAxis = "Vertical";
    public string Jump = "Jump";
    public string Dash = "Dash";
    public string Action = "Action";
    public string Attack = "Attack";

    public Vector2 MoveInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool DashInput { get; private set; }
    public bool ActionInput { get; private set; }
    public bool AttackInput { get; private set; }

    private bool inverted = false;

    public void UpdateInput()
    {
        MoveInput = new Vector2(Input.GetAxis(HorizontalAxis + playerNumber) * (inverted ? -1 : 1), 
                                Input.GetAxis(VerticalAxis + playerNumber) * (inverted ? -1 : 1));

        JumpInput = Input.GetButtonDown(Jump + playerNumber);

        DashInput = Input.GetButtonDown(Dash + playerNumber);

        ActionInput = Input.GetButtonDown(Action + playerNumber);

        AttackInput = Input.GetButtonDown(Attack + playerNumber);
    }

    public void Reverse(float duration)
    {
        inverted = true; 
        
        Timer.Instance.AddToTimer(duration, SetControllerBackToNormal);
    }

    public void SetControllerBackToNormal()
    {
        inverted = false;
    }
}
