using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;
    public Transform projectileSpawnT = null;

    Rigidbody weaponRigidBody = null;
    BoxCollider boxCollider = null;
    PickUpWeaponObject pickUpWeaponObject = null;

    void Awake ()
    {
        weaponRigidBody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        pickUpWeaponObject = GetComponent<PickUpWeaponObject>();
    }

   public void Attack(PlayerAttack attacker)
   {
       if (weaponData.weaponType == WeaponType.Melee)
       {
           attacker.animator.SetTrigger("melee");
       }
       else
       {
           Rigidbody projectileClone = Instantiate(weaponData.projectilePrefab, 
                                                projectileSpawnT.position, 
                                                projectileSpawnT.rotation);
           if (projectileClone != null)
                projectileClone.AddForce(transform.forward * weaponData.projectileSpeed, ForceMode.Impulse);
       }
   }

   public void Carry()
   {
        weaponRigidBody.isKinematic = true;
        boxCollider.enabled = false;
   }

   public void Throw()
   {
        weaponRigidBody.isKinematic = false;
        boxCollider.enabled = true;
        pickUpWeaponObject.IsCarryByPlayer = false;
   }
}
