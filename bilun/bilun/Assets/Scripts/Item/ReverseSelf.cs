using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseSelf : Item, IUsable
{
    public float duration;
    public void Use(PlayerAction actor)
    {
        PlayerInput playerInput = actor.GetComponent<PlayerInput>();
        if (playerInput == null)
            return;

        playerInput.Reverse(duration);
    }
}
