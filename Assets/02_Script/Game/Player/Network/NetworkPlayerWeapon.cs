using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayerWeapon : ExpansionNetworkBehaviour, ILocalInject
{

    private IWeaponHandler _weaponHandler;
    private IFactory<IWeapon> _weaponFactory;

    public void LocalInject(ComponentList list)
    {

        _weaponHandler = list.Find<IWeaponHandler>();
        _weaponFactory = Factory.GetFactory<IWeapon>();

    }

    public override void OnNetworkSpawn()
    {

        if (!IsOwner) return;

        _weaponHandler.OnEquipWeaponEvent += HandleEquipWeapon;

    }

    private void HandleEquipWeapon(PrefabData data)
    {

        _weaponHandler.EquipWeapon(_weaponFactory.CreateInstance(data));

    }

    [ServerRpc]
    private void EquipWeaponServerRPC()
    {



    }

    [ClientRpc]
    private void EquipWeaponClientRPC()
    {



    }

}