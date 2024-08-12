using System.Collections.Generic;
using Unity.Netcode;

public class NetworkPlayerDie : ExpansionNetworkBehaviour, ILocalInject
{

    private IDieable _die;
    private List<IPauseable> _pauses;

    public void LocalInject(ComponentList list)
    {

        _die = list.Find<IDieable>();
        _pauses = list.FindAll<IPauseable>();

    }

    public override void OnNetworkSpawn()
    {

        if (IsOwner)
        {

            _die.OnDieEvent += HandleDieEvent;

        }

    }

    private void HandleDieEvent()
    {

        foreach (var item in _pauses)
        {

            item.Pause();

        }

        PlayerDieServerRPC();

    }

    [ServerRpc]
    private void PlayerDieServerRPC()
    {

        Despawn();

    }

}
