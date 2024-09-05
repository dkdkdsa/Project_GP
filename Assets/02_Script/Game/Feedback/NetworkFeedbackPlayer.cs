using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkFeedbackPlayer : ExpansionNetworkBehaviour, ILocalInject
{
    private IFeedbackPlayer _player = null;

    public void LocalInject(ComponentList list)
    {
        _player = GetComponent<IFeedbackPlayer>();
    }

    public override void OnNetworkSpawn()
    {
        OnRegister();
    }

    public void OnRegister()
    {
        if (_player != null)
        {
            _player.OnStartFeedbackEvent += HandleStartFeedback;
            _player.OnFinishFeedbackEvent += HandleFinishFeedback;
        }
          
    }

    public void UnRegister()
    {
        if (_player != null)
        {
            _player.OnStartFeedbackEvent -= HandleStartFeedback;
            _player.OnFinishFeedbackEvent -= HandleFinishFeedback;
        }
    }

    private void HandleStartFeedback()
    {
        StartFeedbackServerRPC(NetworkManager.LocalClientId);
    }

    private void HandleFinishFeedback()
    {
        FinishFeedbackServerRPC(NetworkManager.LocalClientId);
    }

    [ServerRpc(RequireOwnership = false)]
    private void StartFeedbackServerRPC(ulong localClientId)
    {
        StartFeedbackClientRPC(localClientId.GetRPCParams(false));
    }

    [ServerRpc(RequireOwnership = false)]
    private void FinishFeedbackServerRPC(ulong localClientId)
    {
        FinishFeedbackClientRPC(localClientId.GetRPCParams(false));
    }

    [ClientRpc]
    private void StartFeedbackClientRPC(ClientRpcParams clientRpcParams)
    {
        _player.DoPlayFeedback();
    }

    [ClientRpc]
    private void FinishFeedbackClientRPC(ClientRpcParams clientRpcParams)
    {
        _player.DoFinishFeedback();
    }

    public override void OnNetworkDespawn()
    {
        UnRegister();
    }

    
}
