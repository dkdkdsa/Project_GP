using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{

    private string _playerName = "";
    private string _roomName = "";

    public string PlayerName
    {
        get => _playerName;
        set
        {
            string prevPlayerName = _playerName;

            _playerName = value;
            OnChangedPlayerNameEvent?.Invoke(prevPlayerName, _playerName);
        }
    }

    public string RoomName
    {
        get => _roomName;
        set
        {
            string prevRoomName = _roomName;

            _roomName = value;
        }
    }

    public Action<string, string> OnChangedPlayerNameEvent = null;

}
