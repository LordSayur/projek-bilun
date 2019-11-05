using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon, ISwingable
{
    public void Swing(PlayerAttack actor)
    {
        actor.animator.SetTrigger("melee");
    }

    public override void OnTriggerEnter(Collider other)
    {  
        base.OnTriggerEnter(other);

        if (boxCollider.isTrigger == true)
        {
            if (other.CompareTag("Balloon"))
            {
                BalloonController balloon = other.GetComponent<BalloonController>();
                if (balloon == null)
                    return;

                balloon.DestroyBallon();
            }
        }
    }

    public void OpenCollider()
    {
        boxCollider.enabled = true;
        boxCollider.isTrigger = true;
    }

    public void CloseCollider()
    {
        boxCollider.enabled = false;
        boxCollider.isTrigger = false;
    }
}
