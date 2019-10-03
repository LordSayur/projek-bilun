using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpObject : MonoBehaviour
{
    public bool IsCarryByPlayer {get;set;}
    public abstract void OnTriggerEnter(Collider other);
}
