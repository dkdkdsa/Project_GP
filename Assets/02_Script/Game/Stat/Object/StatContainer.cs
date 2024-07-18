using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatContainer : ExpansionMonoBehaviour, IStatContainer
{

    [SerializeField] protected StatDataSO _data;

    public Dictionary<int, Stat> Container { get; set; } = new();

    protected virtual void Awake()
    {
        
        foreach(var item in _data.Stats)
        {

            Cast<IStatContainer>().AddStat(item.key, item.stat.Clone<Stat>());

        }

    }

}
