using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameText : MonoBehaviour
{
    private TextMeshProUGUI _playerNameTxt = null;

    private void Awake()
    {
        _playerNameTxt = GetComponent<TextMeshProUGUI>();   
    }

    private void OnEnable()
    {
        DataManager.Instance.OnChangedPlayerNameEvent += OnChangedPlayerNameEventHandler;
    }

    private void OnDisable()
    {
        if (DataManager.Instance == null)
            return;
        DataManager.Instance.OnChangedPlayerNameEvent -= OnChangedPlayerNameEventHandler;
    }

    private void OnChangedPlayerNameEventHandler(string prevName, string curName)
    {
        _playerNameTxt.text = curName;
    }
}
