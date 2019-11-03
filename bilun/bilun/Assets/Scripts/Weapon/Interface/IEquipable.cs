using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipable
{
    void Equip(PlayerAttack actor);
    void Unequip(PlayerAttack actor);
}
