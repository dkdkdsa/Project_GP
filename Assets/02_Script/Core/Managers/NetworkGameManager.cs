using Unity.Netcode;

public class NetworkGameManager : NetworkMonoSingleton<NetworkGameManager>
{

    public void StartGame()
    {

        if (!IsServer) return;

        SpawnPlayers();
        DropItemManager.Instance.StartDrop();

    }

    private void SpawnPlayers()
    {

        foreach (var id in NetworkManager.ConnectedClientsIds)
        {

            PlayerManager.Instance.SpawnNetworkPlayer(id);

        }

    }

    public void DiePlayer(ulong diePlayerId)
    {

        RespawnManager.Instance.DiePlayer(diePlayerId, HandleRespawn);

    }

    private void HandleRespawn(ulong id)
    {

        PlayerManager.Instance.SpawnNetworkPlayer(id);

    }

}
