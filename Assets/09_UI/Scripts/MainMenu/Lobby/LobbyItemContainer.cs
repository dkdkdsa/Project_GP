using ExtensionMethod.List;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class LobbyItemContrainer : MonoBehaviour
{
    [SerializeField] private Transform _spawnTrm = null;
    [SerializeField] private LobbyItem _prefab = null;
    private List<LobbyItem> _lobbyItemList = new();


    public void OnSearch()
    {
        ModifyAsync();
    }

    private async void ModifyAsync()
    {
        _lobbyItemList.TryClear(item => Destroy(item.gameObject));
        List<Lobby> lobbyList = new();

        try
        {
            lobbyList = await AppController.Instance.GetLobbyList();
        }
        catch
        {

        }

        if (lobbyList.Equals(new()))
        {
            Debug.LogError("로비가 비어있다");
            return;
        }

        foreach (var lobby in lobbyList)
        {
            LobbyItem obj = Instantiate(_prefab, _spawnTrm);
            _lobbyItemList.Add(obj);

            LobbyItemData item = new LobbyItemData(obj, lobby);
            item.Modify();


        } //end foreach
    }

}
