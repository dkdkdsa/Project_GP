using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponHandler
{

    public void EquipWeapon(IWeapon weapon);
    public void UnEquipWeapon();
    public void AttackWeapon();
    public void RotateWeapon();

}
