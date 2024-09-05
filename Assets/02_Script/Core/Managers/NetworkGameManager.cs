using System;
using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class NetworkGameManager : NetworkMonoSingleton<NetworkGameManager>
{

    public event Action OnGameStarted;

    public void StartGame()
    {

        if (!IsServer) return;

        SpawmMapClientRPC(1);
        SpawnPlayers();
        DropItemManager.Instance.StartDrop();
        StartCoroutine(WaitEndCo());
        GameStartClientRPC();

    }

    private void EndGame()
    {

        ulong winClientId = NetworkScoreManager.Instance.GetHighScoreId();

        Debug.Log($"Win! : {winClientId}");

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

    private IEnumerator WaitEndCo()
    {

        yield return new WaitForSeconds(120f);

        EndGame();

    }

}
