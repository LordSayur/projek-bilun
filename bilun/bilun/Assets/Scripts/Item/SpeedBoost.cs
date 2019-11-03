using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : Item, IUsable
{
    public float increaseValue;
    public float duration;

    public void Use(PlayerAction actor)
    {
        PlayerMovement playerMovement = actor.GetComponent<PlayerMovement>();
        if (playerMovement == null)
            return;

        playerMovement.IncreaseSpeed(increaseValue, duration);
    }
}
