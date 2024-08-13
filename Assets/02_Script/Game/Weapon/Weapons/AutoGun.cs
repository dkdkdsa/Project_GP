using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGun : GunWeapon
{

    private bool _isAttacked;

    public override void Attack(MouseInputType inputType)
    {

        _isAttacked = inputType == MouseInputType.Up ? false : true;

    }

    private void Update()
    {

        if (_shootDelay || !_isAttacked) return;

        ShootBullet();
        ApplyShootDelay();

    }

}
