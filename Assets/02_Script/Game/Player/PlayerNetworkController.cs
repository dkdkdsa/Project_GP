using System.Collections.Generic;

public class PlayerNetworkController : ExpansionNetworkBehaviour, ILocalInject, INetworkObjectController
{

    private List<IPauseable> _pauseAbles;

    public void LocalInject(ComponentList list)
    {

        _pauseAbles = list.FindAll<IPauseable>();

    }

    public override void OnNetworkSpawn()
    {

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
