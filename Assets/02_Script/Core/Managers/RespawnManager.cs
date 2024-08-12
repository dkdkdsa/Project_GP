using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoSingleton<RespawnManager>
{

    [SerializeField] private float _respawnTime = 5;

    private WaitForSeconds _wait;

    private void Awake()
    {
        
        _wait = new WaitForSeconds(_respawnTime);

    }

    public void DiePlayer(ulong playerId, Action<ulong> respawnCallback)
    {

        StartCoroutine(RespawnLogic(playerId, respawnCallback));

    }

    private IEnumerator RespawnLogic(ulong playerId, Action<ulong> respawnCallback)
    {

        yield return _wait;

        respawnCallback?.Invoke(playerId);

    }

}
