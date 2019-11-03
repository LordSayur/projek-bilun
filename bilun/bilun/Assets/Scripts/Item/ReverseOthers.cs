using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseOthers : Item, IUsable
{
    public float duration;
    public void Use(PlayerAction actor)
    {
        foreach(GameObject player in GameManager.Instance.players)
        {
            if (player == actor.gameObject)
                continue;

            PlayerInput playerInput = player.GetComponent<PlayerInput>();
            if (playerInput == null)
                return;

            playerInput.Reverse(duration);
        }
    }
}
