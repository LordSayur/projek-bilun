using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator {get; set;}

    public Transform weaponPlaceHolder = null;
    PlayerInput playerInput = null;

    Weapon equipWeapon = null;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (playerInput.AttackInput)
        {
            if (equipWeapon is IShootable)
            {
                IShootable gun = equipWeapon.GetComponent<IShootable>();
                if (gun != null)
                    gun.Shoot();
            } else if (equipWeapon is ISwingable)
            {
                Melee weapon = equipWeapon.GetComponent<Melee>();
                if (weapon != null)
                    weapon.Swing(this);
            }
        }
    }

    public void Equip(Weapon newWeapon)
    {
        Unequip();

        newWeapon.Equip(this);

        equipWeapon = newWeapon;
    }

    public void Unequip()
    {
        if (equipWeapon == null)
            return;

        equipWeapon.Unequip(this);
        equipWeapon = null;
    }

    public void OpenWeaponCollider()
    {
        if (equipWeapon is ISwingable)
        {
            Melee weapon = (Melee)equipWeapon;
            if (weapon != null)
                weapon.OpenCollider();
        }
    }

    public void CloseWeaponCollider()
    {
        if (equipWeapon is ISwingable)
        {
            Melee weapon = (Melee)equipWeapon;
            if (weapon != null)
                weapon.CloseCollider();
        }
    }
}
