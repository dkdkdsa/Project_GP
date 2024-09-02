using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkFeedbackController : ExpansionNetworkBehaviour, ILocalInject
{
    private IFeedbackHandler _handler = null;

    public void LocalInject(ComponentList list)
    {

    }

    public void SetFeedback(IFeedbackHandler handler)
    {
        if (!IsSpawned)
        {
            Debug.LogError("아직 생성되지 않았습니다.");

            return;
        }

        _handler = handler;

        UnRegister();
        OnRegister();
    }

    public void OnRegister()
    {
        if (_handler != null)
        {
            _handler.OnStartFeedbackEvent += HandleStartFeedback;
            _handler.OnFinishFeedbackEvent += HandleFinishFeedback;
        }
          
    }

    public void UnRegister()
    {
        if (_handler != null)
        {
            _handler.OnStartFeedbackEvent -= HandleStartFeedback;
            _handler.OnFinishFeedbackEvent -= HandleFinishFeedback;
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
        _handler.DoStartFeedback();
    }

    [ClientRpc]
    private void FinishFeedbackClientRPC(ClientRpcParams clientRpcParams)
    {
        _handler.DoFinishFeedback();
    }

    public override void OnNetworkDespawn()
    {
        UnRegister();
    }

    
}
