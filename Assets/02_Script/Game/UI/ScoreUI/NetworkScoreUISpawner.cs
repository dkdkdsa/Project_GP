using System;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

public class NetworkScoreUISpawner : ExpansionNetworkBehaviour
{

    [SerializeField] private Transform[] _spawnTrms;
    [SerializeField] private NetworkObject _prefab; //나중에 팩토리로 바꿀것

    public override void OnNetworkSpawn()
    {

        NetworkGameManager.Instance.OnGameStarted += HandleGameStart;
        
    }

    private void HandleGameStart()
    {

        if (IsServer)
        {

            int cnt = 0;
            foreach (var item in NetworkManager.ConnectedClientsIds)
            {

                var obj = Instantiate(_prefab);
                obj.SpawnWithOwnership(item, true);
                obj.TrySetParent(transform, false);
                SetPositionClientRPC(cnt++, item);

            }

        }

    }

    [ClientRpc]
    private void SetPositionClientRPC(int idx, ulong ownerId)
    {

        var obj = FindObjectsOfType<MonoBehaviour>().ToList().Find((x) =>
        {

            return x is IScoreUI && x.GetComponent<NetworkObject>().OwnerClientId == ownerId;

        });

        obj.transform.localPosition = _spawnTrms[idx].localPosition;

    }

}