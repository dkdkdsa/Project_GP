using Unity.Netcode;

public class NetworkTimeUI : ExpansionNetworkBehaviour, ILocalInject
{

    private ITimeUI<int> _timeUI;

    public void LocalInject(ComponentList list)
    {

        _timeUI = list.Find<ITimeUI<int>>();

    }

    public override void OnNetworkSpawn()
    {

        NetworkGameManager.Instance.OnGameStarted += HandleGameStarted;

    }

    private void HandleGameStarted()
    {

        if (IsServer)
        {

            NetworkGameManager.Instance.EndTimer.RegisterEvent(HandleTimeChanged);
            NetworkGameManager.Instance.OnWinEvent += HandleGameEnd;

        }

    }

    private void HandleGameEnd(ulong end)
    {

        string str = "동점";

        if(end != ulong.MaxValue)
        {

            var data = HostSingle.Instance.GameManager.NetServer.GetUserDataByClientID(end);

            str = $"승리 : {data.Value.nickName}";

        }

        ChangeGameEndClientRPC(str);

    }

    private void HandleTimeChanged(int time)
    {

        ChangeTimeClientRPC(time);

    }

    [ClientRpc]
    private void ChangeTimeClientRPC(int time)
    {

        _timeUI.SetTimeText(time);

    }

    [ClientRpc]
    private void ChangeGameEndClientRPC(string str)
    {

        _timeUI.SetText(str);

    }

}
