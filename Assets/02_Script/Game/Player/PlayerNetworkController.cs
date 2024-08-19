using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetworkController : ExpansionNetworkBehaviour, ILocalInject, INetworkObjectController
{

    private readonly int HASH_COLOR = Shader.PropertyToID("_ColorReplaceToColor");
    private List<IPauseable> _pauseAbles;
    private IRenderer _renderer;

    public void LocalInject(ComponentList list)
    {

        _pauseAbles = list.FindAll<IPauseable>();
        _renderer = list.Find<IRenderer>();

    }

    public override void OnNetworkSpawn()
    {

        if (IsServer)
            SetColorClientRPC(
                HostSingle.Instance
                .GameManager
                .NetServer.GetUserDataByClientID(OwnerClientId).Value.color);

        if (!IsOwner)
        {

            foreach (var item in _pauseAbles)
            {

                item.Pause();

            }

        }
        else
            CameraManager.Instance.SetFollow(transform);

    }

    [ClientRpc]
    private void SetColorClientRPC(Color color)
    {

        _renderer.SetColor(HASH_COLOR, color);

    }

    public void Despawn()
    {

        NetworkObject.Despawn();

    }

    public ulong GetOwner()
    {

        return OwnerClientId;

    }

    bool INetworkObjectController.IsClient() => IsClient;
    bool INetworkObjectController.IsOwner() => IsOwner;
    bool INetworkObjectController.IsServer() => IsServer;

}
