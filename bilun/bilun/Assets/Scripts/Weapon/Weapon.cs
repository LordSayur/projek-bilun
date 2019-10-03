using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;
    public Transform projectileSpawnT = null;

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
}
