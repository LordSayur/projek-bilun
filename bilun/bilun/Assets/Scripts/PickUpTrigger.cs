using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTrigger : MonoBehaviour
{
    public Weapon weapon;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();
            playerAttack.Equip(weapon);

            Destroy(this);
            Destroy(this.GetComponent<SphereCollider>());
        }
    }
}
