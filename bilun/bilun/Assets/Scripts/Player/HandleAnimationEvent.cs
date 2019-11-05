using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAnimationEvent : MonoBehaviour
{
    PlayerAttack playerAttack;

    void Awake()
    {
        playerAttack = GetComponentInParent<PlayerAttack>();
    }

    public void OpenDamage()
    {
        playerAttack.OpenWeaponCollider();
    }

    public void CloseDamage()
    {
        playerAttack.CloseWeaponCollider();
    }
}
