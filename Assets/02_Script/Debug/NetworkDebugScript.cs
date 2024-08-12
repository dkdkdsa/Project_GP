using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NetworkDebugScript : MonoBehaviour
{

    [SerializeField] private GameObject _ui;
    [SerializeField] private TMP_InputField _inputField;

    public async void CreateRoom()
    {

        _ui.SetActive(false);
        await HostSingle.Instance.GameManager.StartHostAsync(Guid.NewGuid().ToString(), default);

    }

    public async void JoinRoom()
    {

        await ClientSingle.Instance.GameManager.StartClientAsync(_inputField.text, default);
        _ui.SetActive(false);

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {

            NetworkGameManager.Instance.StartGame();

        }

        if(Input.GetKeyDown(KeyCode.Z))
        {

            CreateRoom();

        }

        if(Input.GetKeyDown(KeyCode.X))
        {

            JoinRoom();

        }

    }

}
