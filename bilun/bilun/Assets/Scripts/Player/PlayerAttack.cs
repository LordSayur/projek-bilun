using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Weapon currentWeapon = null;

    public Animator animator {get; set;}

    public Transform weaponPlaceHolder = null;
    PlayerInput playerInput = null;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (playerInput.AttackInput)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (currentWeapon != null)
            currentWeapon.Attack(this);
    }

    public void Equip(Weapon newWeapon)
    {
        Unequip();

        newWeapon.transform.parent = weaponPlaceHolder;
        newWeapon.transform.localPosition = newWeapon.weaponData.holdPosition;
        newWeapon.transform.localRotation = Quaternion.Euler(newWeapon.weaponData.holdRotation);

        currentWeapon = newWeapon;

        if (newWeapon.weaponData.weaponType == WeaponType.Ranged)
        {
            animator.SetBool("ranged", true);
        }
    }

    public void Unequip()
    {
        if (currentWeapon == null)
            return;

       if (currentWeapon.weaponData.weaponType == WeaponType.Ranged)
        {
            animator.SetBool("ranged", false);
        }

        currentWeapon.transform.parent = null;

        Destroy(currentWeapon.gameObject);

        currentWeapon = null;
    }
}
