using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>, ILocalInject
{

    private IFactory<Player> _playerFactory;
    private List<Player> _players = new();

    public void LocalInject(ComponentList list)
    {

        _playerFactory = Factory.GetFactory<Player>();

    }

    public Player SpawnPlayer()
    {

        var obj = _playerFactory.CreateInstance();
        _players.Add(obj);
        return obj;

    }

}
