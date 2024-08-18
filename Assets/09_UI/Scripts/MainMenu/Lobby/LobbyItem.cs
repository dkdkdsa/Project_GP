using System.Collections;
using System.Collections.Generic;
using System.Security;
using TMPro;
using UnityEngine;

public class LobbyItem : MonoBehaviour
{
    public TextMeshProUGUI HostPlayerNameTxt = null;
    public TextMeshProUGUI LobbyNameTxt = null;
    public TextMeshProUGUI PlayerCountTxt = null;
    public TextMeshProUGUI PlayerMaxCountTxt = null;

    private string _joincode = string.Empty;
    private int _maxPlayerCount = 4;
    private int _playerCount = 0;

    #region Setting

    public void SetHostPlayerName(string playerName)
    {
        HostPlayerNameTxt.text = playerName;
    }

    public void SetLobbyName(string lobbyName)
    {
        LobbyNameTxt.text = lobbyName; 
    }

    public void SetPlayerCount(int playerCount, int maxCount = 4)
    {
        _playerCount = playerCount;
        _maxPlayerCount = maxCount;

        PlayerCountTxt.text = _playerCount.ToString();
        PlayerMaxCountTxt.text = _maxPlayerCount.ToString();
    }

    public void SetJoincode(string joincode)
    {
        _joincode = joincode;
    }

    #endregion

    //버튼 이벤트
    public void OnJoinRoom()
    {
        JoinRoom();
    }

    private async void JoinRoom()
    {
        await ClientSingle.Instance.GameManager.StartClientAsync(_joincode, default);
    }
}
