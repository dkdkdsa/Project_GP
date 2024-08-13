using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public interface IController<T> : IControllerable
{
    public IController<T> GetController();
}

public interface IControllerable 
{
    public abstract void Init();
}

public class ControllerContainer : MonoSingleton<ControllerContainer>
{
    private List<IControllerable> _controllers;

    private void Awake()
    {
        if (_controllers == null)
            InitContainer();

    }

    private void InitContainer()
    {

        _controllers = GetComponentsInChildren<IControllerable>().ToList();

        foreach(var item in _controllers)
        {
            item.Init();
        }
    }

    public IController<T> GetController<T>()
    {

        if (_controllers == null)
            InitContainer();

        foreach (var item in _controllers)
        {

            if (item is IController<T>)
                return item.Cast<IController<T>>();

        }

        return null;

    }

}
