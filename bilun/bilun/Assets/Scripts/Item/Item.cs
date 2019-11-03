using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAction playerAction = other.GetComponent<PlayerAction>();
            if (playerAction == null)
                return;

            playerAction.Pick(this);
            Destroy(gameObject);
        }
    }
}
