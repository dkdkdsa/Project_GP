using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayerMovement : ExpansionNetworkBehaviour, ILocalInject
{

    private IMoveable _move;

    public void LocalInject(ComponentList list)
    {

        _move = list.Find<IMoveable>();

    }

    public override void OnNetworkSpawn()
    {

        if (IsOwner)
        {

            _move.OnChangedInputVector += HandleValueChanged;

        }

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