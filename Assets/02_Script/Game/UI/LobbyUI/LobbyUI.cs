using System.Threading.Tasks;
using TMPro;
using Unity.Netcode;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : ExpansionNetworkBehaviour
{

    [SerializeField] private TMP_Text _joinCodeText, _roomNameText, _roomCountText;
    [SerializeField] private TMP_Text _title;
    [SerializeField] private Button _playBtn;
    [SerializeField] private RectTransform _parent;
    [SerializeField] private PlayerInfoElement _playerInfoPrefab;

    private void Start()
    {
        if(IsHost)
        {
            InitializeUI();
            _playBtn.gameObject.SetActive(true);
        }
    }

    private async void InitializeUI()
    {
        _joinCodeText.text = string.Format("CODE: {0}", HostSingle.Instance.GameManager.JoinCode);
        Lobby lobby = await Lobbies.Instance.GetLobbyAsync(HostSingle.Instance.GameManager.LobbyId);
        if(lobby == null)
        {
            Debug.LogError("Lobby is not found!");
            return;
        }

        _roomNameText.text = lobby.Name;
        _title.text = lobby.Name;
        _roomCountText.text = string.Format("{0} / 4", lobby.Players.Count);
        foreach (var player in NetworkManager.ConnectedClientsIds)
        {
            PlayerInfoElement elem = Instantiate(_playerInfoPrefab, _parent);
            UserData? data = HostSingle.Instance.NetServer.GetUserDataByClientID(player);
            if(data == null)
            {
                Debug.LogError($"Client ID {player} is not exist!");
                continue;
            }
            elem.Init(data.Value.nickName, data.Value.color, player == OwnerClientId);
            CreateElementClientRpc(data.Value.nickName, player == OwnerClientId, data.Value.color);
        }

        InitializeUIClientRpc(lobby.Name, _roomCountText.text, _joinCodeText.text);
    }

    [ClientRpc]
    private void InitializeUIClientRpc(string roomName, string roomCountText, string joinCode)
    {
        if (IsHost) return;

        _joinCodeText.text = joinCode;
        _roomNameText.text = roomName;
        _title.text = roomName;
        _roomCountText.text = roomCountText;
    }

    [ClientRpc]
    private void CreateElementClientRpc(string name, bool isHost, Color color)
    {
        PlayerInfoElement elem = Instantiate(_playerInfoPrefab);
        elem.Init(name, color, isHost);
    }
}
