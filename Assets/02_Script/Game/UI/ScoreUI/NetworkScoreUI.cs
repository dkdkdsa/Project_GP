using System.Linq;
using Unity.Netcode;
using UnityEngine;

public class NetworkScoreUI : ExpansionNetworkBehaviour, ILocalInject
{

    private IScoreUI _scoreUI;
    private IScoreController<ulong, int> _scoreController;

    public void LocalInject(ComponentList list)
    {

        _scoreUI = list.Find<IScoreUI>();
        _scoreController = FindObjectsOfType<MonoBehaviour>().ToList().Find(x =>
        {

            return x is IScoreController<ulong, int>;

        }) as IScoreController<ulong, int>;

    }

    public override void OnNetworkSpawn()
    {

        if (IsServer)
        {

            _scoreController.RegisterScoreChangeEvent(HandleScoreChanged);

            var data = HostSingle.Instance.NetServer.GetUserDataByClientID(OwnerClientId);

            SetNameClientRPC(data.Value.nickName);
            SetPlayerColorClientRPC(data.Value.color);
            SetScoreClientRPC(0);

        }

        if (IsOwner)
        {

            _scoreUI.SetNameColor(Color.red);

        }

    }

    [ClientRpc]
    private void SetPlayerColorClientRPC(Color color)
    {

        _scoreUI.SetPlayerColor(color);

    }

    private void HandleScoreChanged(ulong id, int score)
    {

        Debug.Log(id);
        if (id != OwnerClientId)
            return;

        SetScoreClientRPC(score);

    }

    [ClientRpc]
    private void SetScoreClientRPC(int score)
    {

        _scoreUI.SetScoreText(score);

    }

    [ClientRpc]
    private void SetNameClientRPC(string name)
    {

        _scoreUI.SetPlayerName(name);

    }

}