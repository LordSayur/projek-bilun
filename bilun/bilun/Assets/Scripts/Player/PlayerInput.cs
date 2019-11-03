using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
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
        MoveInput = new Vector2(Input.GetAxis(HorizontalAxis) * (inverted ? -1 : 1), 
                                Input.GetAxis(VerticalAxis) * (inverted ? -1 : 1));

        JumpInput = Input.GetButtonDown(Jump);

        DashInput = Input.GetButtonDown(Dash);

        ActionInput = Input.GetButtonDown(Action);

        AttackInput = Input.GetButtonDown(Attack);
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
