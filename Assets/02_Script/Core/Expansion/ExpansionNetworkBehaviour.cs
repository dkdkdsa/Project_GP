using Unity.Netcode;

public class ExpansionNetworkBehaviour : NetworkBehaviour
{

    public T Cast<T>()
    {

        return Support.Cast<T>(this);

    }


    public void Despawn(bool destroy = true)
    {

        NetworkObject.Despawn(destroy);

    }

}
