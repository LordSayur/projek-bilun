using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;

   public void Attack(PlayerAttack attacker)
   {
       if (weaponData.weaponType == WeaponType.Melee)
       {
           attacker.animator.SetTrigger("melee");
       }
       else
       {
           Debug.Log("Phew! Phew!");
       }
   }
}
