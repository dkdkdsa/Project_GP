using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutoGun : GunWeapon
{
    public override void Attack(MouseInputType inputType)
    {

        if (_shootDelay) return;

        if(inputType == MouseInputType.Down)
        {

            ShootBullet();
            ApplyShootDelay();

        }

    }


}
