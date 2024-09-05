using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkScoreManager : NetworkMonoSingleton<NetworkScoreManager>, IScoreController<ulong, int>
{

    private class AttackObjectData
    {

        public ulong attackClientId = ulong.MaxValue;
        public Coroutine coroutine;

    }


    [SerializeField] private float _killWaitTime;

    private Dictionary<ulong, AttackObjectData> _attackDataContainer = new();
    private Dictionary<ulong, int> _scoreContainer = new();
    private Action<ulong, int> _changeEvent;

    public void CatchAttack(ulong targetClient, ulong attackClient)
    {

        if (!_attackDataContainer.ContainsKey(targetClient))
        {

            _attackDataContainer.Add(targetClient, new AttackObjectData());

        }

        var obj = _attackDataContainer[targetClient];

        obj.attackClientId = attackClient;

        if (obj.coroutine != null)
            StopCoroutine(obj.coroutine);

        obj.coroutine = StartCoroutine(AttackTargetCo(targetClient));

    }

    public void CatchDie(ulong dieClientId)
    {

        if (_attackDataContainer.TryGetValue(dieClientId, out var v))
        {

            if (v.attackClientId != ulong.MaxValue)
            {

                AddScore(v.attackClientId);

            }

        }

    }

    private void AddScore(ulong target)
    {

        if (!_scoreContainer.ContainsKey(target))
        {

            _scoreContainer.Add(target, 0);

        }

        int score = ++_scoreContainer[target];
        _changeEvent?.Invoke(target, score);

    }

    private IEnumerator AttackTargetCo(ulong targetClient)
    {

        yield return new WaitForSeconds(_killWaitTime);
        _attackDataContainer[targetClient].attackClientId = ulong.MaxValue;
        _attackDataContainer[targetClient].coroutine = null;

    }

    public ulong GetHighScoreId()
    {

        int minScore = int.MinValue;
        ulong targetId = ulong.MaxValue;

        foreach(var item in _scoreContainer) 
        { 
            
            if(item.Value > minScore)
            {

                minScore = item.Value;
                targetId = item.Key;

            }
        
        }

        return targetId;

    }

    public int GetScore(ulong key)
    {

        return _scoreContainer[key];

    }

    public void RegisterScoreChangeEvent(Action<ulong, int> action)
    {
        _changeEvent += action;
    }

    public void UnRegisterScoreChangeEvent(Action<ulong, int> action)
    {
        _changeEvent -= action;
    }

}