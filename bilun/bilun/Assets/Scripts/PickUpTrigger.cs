using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTrigger : MonoBehaviour
{
    public Weapon weapon;
    public bool isCarry {get;set;}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCarry)
        {
            PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();
            playerAttack.Equip(weapon);
            isCarry = true;
        }
    }
}
