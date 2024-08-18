using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateRoomUI : UIComponent
{
    [SerializeField] private TMP_InputField _lobbyNameField = null;
    public void OnCreateRoom()
    {
        CreateRoom();
    }

    private async void CreateRoom()
    {
        string name = DataManager.Instance.PlayerName;

        await AppController.Instance.StartHostAsync(name, _lobbyNameField.text);
    }
}
