using Unity.Netcode;

public class PlayerManager : MonoSingleton<PlayerManager>, ILocalInject
{

    private IFactory<Player> _playerFactory;

    public void LocalInject(ComponentList list)
    {

        _playerFactory = Factory.GetFactory<Player>();

    }

    public Player SpawnPlayer()
    {

        var obj = _playerFactory.CreateInstance();
        return obj;

    }

    public void SpawnNetworkPlayer(ulong id)
    {

        var player = SpawnPlayer();
        player.GetComponent<NetworkObject>().SpawnAsPlayerObject(id);

    }

}
