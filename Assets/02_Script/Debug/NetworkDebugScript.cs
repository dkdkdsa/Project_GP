using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class NetworkDebugScript : MonoBehaviour
{

    [SerializeField] private GameObject _ui;
    [SerializeField] private TMP_InputField _inputField;

    public async void CreateRoom()
    {

        _ui.SetActive(false);
        await HostSingle.Instance.GameManager.StartHostAsync(Guid.NewGuid().ToString(), AppController.Instance.GetUserData("ADSF", Random.ColorHSV()));

    }

    public async void JoinRoom()
    {

        await ClientSingle.Instance.GameManager.StartClientAsync(_inputField.text, AppController.Instance.GetUserData("ADSF", Random.ColorHSV()));
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
