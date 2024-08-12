using UnityEngine;

[RequireComponent(typeof(ObjectDieSencer))]
public class NetworkObjectDieSencer : ExpansionNetworkBehaviour, ILocalInject
{

    private IPauseable _dieSencer;

    public void LocalInject(ComponentList list)
    {

        _dieSencer = GetComponent<IPauseable>();

    }

    public override void OnNetworkSpawn()
    {

        if (!IsServer)
        {

            _dieSencer.Pause();

        }

    }

}
