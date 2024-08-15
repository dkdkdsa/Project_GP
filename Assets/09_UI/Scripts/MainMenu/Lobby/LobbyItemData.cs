using System.Collections;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public struct LobbyItemData
{
    private LobbyItem _prefab;
    private Lobby _lobby;

    public LobbyItemData(LobbyItem prefab, Lobby lobby)
    {
        this._prefab = prefab;
        this._lobby = lobby;
    }

    public void Modify()
    {
        _prefab.SetLobbyName(_lobby.Name);
        _prefab.SetPlayerCount(int.Parse(_lobby.Data["Players"].Value), _lobby.MaxPlayers);
        _prefab.SetJoincode(_lobby.Data["JoinCode"].Value);
    }

}
