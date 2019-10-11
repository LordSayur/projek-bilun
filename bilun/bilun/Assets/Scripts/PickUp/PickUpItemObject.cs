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
            else if (itemData.attributeType == AttributeType.Invert)
            {
                if (itemData.targetType == TargetType.Self)
                {
                    PlayerInput playerInput = other.GetComponent<PlayerInput>();
                    if (playerInput == null)
                        return;

                    playerInput.ReverseController(itemData.duration);
                }
                else if (itemData.targetType == TargetType.All)
                {
                    foreach(GameObject spawnObject in GameManager.Instance.players)
                    {
                        PlayerInput playerInput = spawnObject.GetComponent<PlayerInput>();
                        if (playerInput == null)
                            return;

                        playerInput.ReverseController(itemData.duration);
                    }
                }
                else if (itemData.targetType == TargetType.AllExceptSelf)
                {
                    List<GameObject> targets = new List<GameObject>();
                    foreach(GameObject spawnObject in GameManager.Instance.players)
                    {
                        if (spawnObject != other.gameObject)
                        {
                            targets.Add(spawnObject);
                        }
                    }
                    foreach(GameObject target in targets)
                    {
                        PlayerInput playerInput = target.GetComponent<PlayerInput>();
                        if (playerInput == null)
                            return;

                        playerInput.ReverseController(itemData.duration);
                    }
                }
            }     

            Destroy(gameObject);
        }
    }
}
