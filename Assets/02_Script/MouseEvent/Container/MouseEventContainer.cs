using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public interface IMouseEvent<T> : IMouseEventable
{
    public IMouseEvent<T> GetController();
}

public interface IMouseEventable 
{
    public abstract void Init();
}


public class MouseEventContainer : MonoSingleton<MouseEventContainer>
{
    private List<IMouseEventable> _mouseEventControllers;

    private void Awake()
    {
        if (_mouseEventControllers == null)
            InitContainer();

    }

    private void InitContainer()
    {

        _mouseEventControllers = GetComponentsInChildren<IMouseEventable>().ToList();

        foreach(var item in _mouseEventControllers)
        {
            item.Init();
        }
    }

    public IMouseEvent<T> GetMouseEventController<T>()
    {

        if (_mouseEventControllers == null)
            InitContainer();

        foreach (var item in _mouseEventControllers)
        {

            if (item is IMouseEvent<T>)
                return item.Cast<IMouseEvent<T>>();

        }

        return null;

    }

}
