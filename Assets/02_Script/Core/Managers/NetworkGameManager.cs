using Unity.Netcode;

public class NetworkGameManager : NetworkMonoSingleton<NetworkGameManager>
{

    public void StartGame()
    {

        if (!IsServer) return;

        SpawnPlayers();

    }

    private void SpawnPlayers()
    {

        foreach (var id in NetworkManager.ConnectedClientsIds)
        {

            var player = PlayerManager.Instance.SpawnPlayer();
            player.GetComponent<NetworkObject>().SpawnWithOwnership(id, true);

        }

    }

}
