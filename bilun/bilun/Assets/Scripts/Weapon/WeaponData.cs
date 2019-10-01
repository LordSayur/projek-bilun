using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "WeaponData", menuName = "WeaponData" )]
public class WeaponData : ScriptableObject
{
    public WeaponType weaponType = WeaponType.Melee;
    public int damage = 1;

    public Vector3 holdPosition = Vector3.zero;
    public Vector3 holdRotation = Vector3.zero;
}

public enum WeaponType {
    Melee,
    Ranged
}
