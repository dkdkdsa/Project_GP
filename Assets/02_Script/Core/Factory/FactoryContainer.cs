using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FactoryContainer : MonoSingleton<FactoryContainer>
{

    private List<IFactoryable> _factorys;

    private void Awake()
    {

        if (_factorys == null)
            InitContainer();

    }

    private void InitContainer()
    {

        _factorys = GetComponentsInChildren<IFactoryable>().ToList();

    }

    public IFactory<T> GetFactory<T>()
    {

        if(_factorys == null)
            InitContainer();

        foreach(var item in _factorys)
        {

            if(item is IFactory<T>)
                return item.Cast<IFactory<T>>();

        }

        return null;

    }

}