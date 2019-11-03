using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : Item, IUsable
{
    public float decreaseValue;
    public float duration;

    public void Use(PlayerAction actor)
    {
        PlayerMovement playerMovement = actor.GetComponent<PlayerMovement>();
        if (playerMovement == null)
            return;

        playerMovement.DecreaseSpeed(decreaseValue, duration);
    }
}
