using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayerMovement : ExpansionNetworkBehaviour, ILocalInject
{

    private IMoveable _move;
    private IKnockBackable _knockBack;

    public void LocalInject(ComponentList list)
    {

        _move = list.Find<IMoveable>();
        _knockBack = list.Find<IKnockBackable>();

    }

    public override void OnNetworkSpawn()
    {

        if (IsOwner)
        {

            _move.OnChangedInputVector += HandleValueChanged;

        }

        if (IsServer && !IsOwner)
        {

            _knockBack.OnKnockBackEvent += HandleKnockBack;

        }

    }

    private void HandleKnockBack(float force, Vector2 vec)
    {

        KnockBackClientRPC(force, vec, OwnerClientId.GetRPCParams());

    }

    [ClientRpc]
    private void KnockBackClientRPC(float force, Vector2 vec, ClientRpcParams @params)
    {

        _knockBack.KnockBack(force, vec);

    }

    private void HandleValueChanged(Vector2 vector)
    {

        ChangeValueServerRPC(vector);

    }

    [ServerRpc]
    private void ChangeValueServerRPC(Vector2 value)
    {

        ChangeValueClientRPC(value);

    }

    [ClientRpc]
    private void ChangeValueClientRPC(Vector2 value)
    {

        if (IsOwner) return;

        _move.SetInputVector(value);

    }

}