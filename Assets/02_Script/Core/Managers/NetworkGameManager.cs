using System;
using System.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkGameManager : NetworkMonoSingleton<NetworkGameManager>
{

    public event Action OnGameStarted;
    public event Action<ulong> OnWinEvent;
    public ITimer<int> EndTimer { get; private set; }

    public void StartGame()
    {

        if (!IsServer) return;

        SpawmMapClientRPC(1);
        SpawnPlayers();
        DropItemManager.Instance.StartDrop();

        EndTimer = TimerHelper.StartTimer<int, IntTimer>(30);
        EndTimer.RegisterEndEvent(EndGame);

        GameStartClientRPC();

    }

    private void EndGame()
    {

        ulong winClientId = NetworkScoreManager.Instance.GetHighScoreId();
        OnWinEvent?.Invoke(winClientId);

        var t = TimerHelper.StartTimer<int, IntTimer>(10);
        t.RegisterEndEvent(async () =>
        {

            NetworkManager.SceneManager.LoadScene("MainMenuSceneTest", LoadSceneMode.Single);
            await HostSingle.Instance.GameManager.ShutdownAsync();

        });

    }

    private void SpawnPlayers()
    {

        foreach (var id in NetworkManager.ConnectedClientsIds)
        {

            PlayerManager.Instance.SpawnNetworkPlayer(id);

        }

    }

    [ClientRpc]
    private void GameStartClientRPC()
    {

        OnGameStarted?.Invoke();

    }

    public void AttackPlayer(ulong targetId, ulong attackId)
    {

        NetworkScoreManager.Instance.CatchAttack(targetId, attackId);

    }

    public void DiePlayer(ulong diePlayerId)
    {

        NetworkScoreManager.Instance.CatchDie(diePlayerId);
        RespawnManager.Instance.DiePlayer(diePlayerId, HandleRespawn);

    }

    private void HandleRespawn(ulong id)
    {

        PlayerManager.Instance.SpawnNetworkPlayer(id);

    }

    [ClientRpc]
    private void SpawmMapClientRPC(int id)
    {

        MapManager.Instance.LoadMap(id);

    }

}
