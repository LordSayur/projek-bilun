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

<<<<<<< HEAD
    private bool inverted = false;

=======
>>>>>>> 43800bc5b8feebc79583d09c0cac5b3f55ef5c68
    public void UpdateInput()
    {
        MoveInput = new Vector2(Input.GetAxis(HorizontalAxis), Input.GetAxis(VerticalAxis));

        JumpInput = Input.GetButtonDown(Jump);

        DashInput = Input.GetButtonDown(Dash);

        ActionInput = Input.GetButtonDown(Action);

        AttackInput = Input.GetButtonDown(Attack);
<<<<<<< HEAD
    }

    public void Reverse(float duration)
    {
        inverted = true; 
        
        Timer.Instance.AddToTimer(duration, SetControllerBackToNormal);
    }

    public void SetControllerBackToNormal()
    {
        inverted = false;
=======
>>>>>>> 43800bc5b8feebc79583d09c0cac5b3f55ef5c68
    }
}
