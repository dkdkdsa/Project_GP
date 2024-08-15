using System.Collections;
using System.Collections.Generic;
using System.Security;
using TMPro;
using UnityEngine;

public class LobbyItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hostPlayerNameTxt = null;
    [SerializeField] private TextMeshProUGUI _LobbyNameTxt = null;
    [SerializeField] private TextMeshProUGUI _playerCountTxt = null;
    [SerializeField] private TextMeshProUGUI _playerMaxCountTxt = null;

    private string _joincode = string.Empty;
    private int _maxPlayerCount = 4;
    private int _playerCount = 0;

    #region Setting

    public void SetHostPlayerName(string playerName)
    {
        _hostPlayerNameTxt.text = playerName;
    }

    public void SetLobbyName(string lobbyName)
    {
        _LobbyNameTxt.text = lobbyName;
    }

    public void SetPlayerCount(int playerCount, int maxCount = 4)
    {
        _playerCount = playerCount;
        _maxPlayerCount = maxCount;

        _playerCountTxt.text = _playerCount.ToString();
        _playerMaxCountTxt.text = _maxPlayerCount.ToString();
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
