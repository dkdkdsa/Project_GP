using Unity.Netcode;

public class ExpansionNetworkBehaviour : NetworkBehaviour
{

    public T Cast<T>()
    {

        return Support.Cast<T>(this);

    }

}
