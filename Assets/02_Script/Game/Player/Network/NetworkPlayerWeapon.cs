using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayerWeapon : ExpansionNetworkBehaviour, ILocalInject
{

    private IWeaponHandler _weaponHandler;

    public void LocalInject(ComponentList list)
    {

        _weaponHandler = list.Find<IWeaponHandler>();

    }

}