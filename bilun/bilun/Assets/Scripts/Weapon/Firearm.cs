using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearm : Weapon, IShootable
{
    public Transform projectileSpawnT = null;
    public Rigidbody projectilePrefab = null;
    public float projectileSpeed = 20f;

    public override void Equip(PlayerAttack actor)
    {
        base.Equip(actor);

        actor.animator.SetBool("ranged", true);
    }

    public override void Unequip(PlayerAttack actor)
    {
        base.Unequip(actor);

        actor.animator.SetBool("ranged", false);
    }

    public void Shoot()
    {
        Rigidbody projectileClone = Instantiate(projectilePrefab, 
                                                projectileSpawnT.position, 
                                                projectileSpawnT.rotation);
        if (projectileClone != null)
            projectileClone.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
    }
}
