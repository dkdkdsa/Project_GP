using ControllerSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkSelectIconTarget : ExpansionNetworkBehaviour, ILocalInject
{
    [SerializeField] private Transform _rootTrm = null;

    private ISelectHandler _handler = null;

    public void LocalInject(ComponentList list)
    {
        _handler = list.Find<ISelectHandler>();
    }

    public override void OnNetworkSpawn()
    {

        _handler.OnShowSelectIconEvent += HandleShowIcon;
        _handler.OnHideSelectIconEvent += HandleHideIcon;

    }

    private void HandleShowIcon(SelectIconType type)
    {
        ShowIconServerRPC(type, NetworkManager.LocalClientId);
    }

    private void HandleHideIcon()
    {
        HideIconServerRPC(NetworkManager.LocalClientId);
    }

    [ServerRpc(RequireOwnership = false)]
    private void ShowIconServerRPC(SelectIconType type, ulong localClientId)
    {

        ShowIconClientRPC(type, localClientId.GetRPCParams(false));

    }

    [ServerRpc(RequireOwnership = false)]
    private void HideIconServerRPC(ulong localClientId)
    {
        HideIconClientRPC(localClientId.GetRPCParams(false));
    }

    [ClientRpc]
    private void ShowIconClientRPC(SelectIconType type, ClientRpcParams clientRpcParams)
    {

        _handler.SetShowSelectIconType(type);
        _handler.DoShowSelectIcon();
    }

    [ClientRpc]
    private void HideIconClientRPC(ClientRpcParams clientRpcParams)
    {

        _handler.DoHideSelectIcon();
    }
}
