using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkHitCaster : ExpansionNetworkBehaviour, ILocalInject
{

    private IHitCaster _targetCaster;

    public void LocalInject(ComponentList list)
    {

        _targetCaster = list.Find<IHitCaster>();

    }

    public override void OnNetworkSpawn()
    {


        if (IsOwner)
        {

            _targetCaster.OnCasting += HandleOnCasting;

        }

    }

    private bool HandleOnCasting(CastData data)
    {

        SendCastingServerRPC(data);

        return false;

    }

    [ServerRpc]
    private void SendCastingServerRPC(CastData data)
    {

        _targetCaster.CastingDamage(in data);
        _targetCaster.CastingKnockback(in data);

    }

}
