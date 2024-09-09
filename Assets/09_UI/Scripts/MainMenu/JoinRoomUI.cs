using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JoinRoomUI : MonoBehaviour
{

    [SerializeField] private TMP_InputField _inputField;

    public async void Load()
    {

        string name = DataManager.Instance.PlayerName;
        await AppController.Instance.StartClientAsync(name, _inputField.text);

    }

}
