using System.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

public class CheckClientJoin : ExpansionNetworkBehaviour
{

    [SerializeField] private UnityEvent _joinEvent;
    private int _count;

    private void Start()
    {

        if (IsServer)
            StartCoroutine(WaitCo());
        JoinServerRpc();

    }

    [ServerRpc(RequireOwnership = false)]
    private void JoinServerRpc()
    {

        _count++;

    }

    private IEnumerator WaitCo()
    {

        yield return new WaitUntil(() => _count == NetworkManager.ConnectedClients.Count);

        _joinEvent?.Invoke();

    }

}
