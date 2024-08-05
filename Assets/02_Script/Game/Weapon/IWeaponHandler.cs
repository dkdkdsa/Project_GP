using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponHandler
{

    public event Action<PrefabData> OnEquipWeaponEvent;
    public event Action OnUnEquipWeaponEvent;
    public event Action OnAttackWeaponEvent;

    public void EquipWeapon(IWeapon weapon);
    public void UnEquipWeapon();
    public void AttackWeapon();
    public void RotateWeapon();

}
