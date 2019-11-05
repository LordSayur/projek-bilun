using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon, ISwingable
{
    bool hasHit = false;

    public void Swing(PlayerAttack actor)
    {
        actor.animator.SetTrigger("melee");
    }

    public override void OnTriggerEnter(Collider other)
    {  
        base.OnTriggerEnter(other);

        if (boxCollider.isTrigger == true)
        {
            if (other.CompareTag("Balloon") && !hasHit)
            {
                hasHit = true;
                BalloonController balloon = other.GetComponent<BalloonController>();
                if (balloon == null)
                    return;

                balloon.DestroyBallon();
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {  
        if (boxCollider.isTrigger == true)
        {
            if (collision.gameObject.CompareTag("Balloon"))
            {
                hasHit = false;
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
