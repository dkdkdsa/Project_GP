using Unity.Netcode;

public class ExpansionNetworkBehaviour : NetworkBehaviour
{

    public T Cast<T>()
    {

        return Support.Cast<T>(this);

    }


    public void Despawn(bool destroy = true)
    {

        if (IsServer)
        {

            NetworkObject.Despawn(destroy);
            
        }
        else
        {

            DespawnServerRPC(destroy);

        }

    }

    [ServerRpc(RequireOwnership = false)]
    private void DespawnServerRPC(bool destroy)
    {

        Despawn(destroy);

    }



}
