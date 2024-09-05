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
            NetworkGameManager.Instance.EndTimer.RegisterEndEvent(HandleGameEnd);

        }

    }

    private void HandleGameEnd()
    {

        ChangeGameEndClientRPC();

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
    private void ChangeGameEndClientRPC()
    {

        _timeUI.SetText("게임종료");

    }

}
