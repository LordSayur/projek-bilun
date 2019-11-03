using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon, ISwingable
{
    public void Swing(PlayerAttack attacker)
    {
        attacker.animator.SetTrigger("melee");
    }
}
