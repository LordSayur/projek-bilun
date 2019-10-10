using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemObject : PickUpObject
{
    public ItemData itemData;

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (itemData.attributeType == AttributeType.Speed)
            {
                PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
                if (playerMovement == null)
                    return;

                playerMovement.ChangeSpeed(itemData.changeValue, itemData.duration);
            }            

            Destroy(gameObject);
        }
    }
}
