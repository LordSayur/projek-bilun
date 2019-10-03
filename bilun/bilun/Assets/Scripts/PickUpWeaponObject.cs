using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeaponObject : PickUpObject
{
    public Weapon weapon {get;set;}

    void Awake()
    {
        weapon = GetComponent<Weapon>();
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !IsCarryByPlayer)
        {
            PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();
            if (playerAttack == null)
                return;
                
            playerAttack.Equip(weapon);

            IsCarryByPlayer = true;
        }
    }
}
