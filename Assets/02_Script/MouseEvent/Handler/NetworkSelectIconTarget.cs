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

        if (!IsOwner) return;

        _handler.OnShowSelectIconEvent += HandleShowIcon;
        _handler.OnHideSelectIconEvent += HandleHideIcon;

    }

    private void HandleShowIcon(SelectIconType type)
    {
        ShowIconServerRPC(type);
    }

    private void HandleHideIcon()
    {
        HideIconServerRPC();
    }

    [ServerRpc]
    private void ShowIconServerRPC(SelectIconType type)
    {

        ShowIconClientRPC(type);

    }

    [ServerRpc]
    private void HideIconServerRPC()
    {
        HideIconClientRPC();
    }

    [ClientRpc]
    private void ShowIconClientRPC(SelectIconType type)
    {

        if (IsOwner) return;

        _handler.SetShowSelectIconType(type);
        _handler.ShowSelectIcon(_rootTrm);
    }

    [ClientRpc]
    private void HideIconClientRPC()
    {
        if (IsOwner) return;

        _handler.HideSelectIcon();
    }
}
