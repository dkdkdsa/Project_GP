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

        EquipWeaponServerRPC(data);

    }

    [ServerRpc]
    private void EquipWeaponServerRPC(PrefabData data)
    {

        EquipWeaponClientRPC(data);

    }

    [ClientRpc]
    private void EquipWeaponClientRPC(PrefabData data)
    {

        if (IsOwner) return;

        _weaponHandler.EquipWeapon(_weaponFactory.CreateInstance(data));

    }

}