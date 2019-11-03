using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IEquipable
{
    public Vector3 holdPosition = Vector3.zero;
    public Vector3 holdRotation = Vector3.zero;

    Rigidbody weaponRigidBody = null;
    BoxCollider boxCollider = null;

    bool isCarry = false;

    void Awake ()
    {
        weaponRigidBody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

   public virtual void Equip(PlayerAttack actor)
   {
        weaponRigidBody.isKinematic = true;
        boxCollider.enabled = false;
        isCarry = true;

        transform.parent = actor.weaponPlaceHolder;
        transform.localPosition = holdPosition;
        transform.localRotation = Quaternion.Euler(holdRotation);
   }

   public virtual void Unequip(PlayerAttack actor)
   {
        transform.parent = null;
        
        weaponRigidBody.isKinematic = false;
        boxCollider.enabled = true;
        isCarry = false;
   }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCarry)
        {
            PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();
            if (playerAttack == null)
                return;
                
            playerAttack.Equip(this);
        }
    }
}
