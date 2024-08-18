using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{

    #region PlayerName

    private string _playerName = "";

    public string PlayerName
    {
        get => _playerName;
        set
        {
            string prevNmae = _playerName;

            _playerName = value;
            OnChangedPlayerNameEvent?.Invoke(prevNmae, _playerName);
        }
    }

    public Action<string, string> OnChangedPlayerNameEvent = null;

    #endregion

}
