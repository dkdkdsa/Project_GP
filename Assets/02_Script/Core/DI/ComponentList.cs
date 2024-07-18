using UnityEngine;

public class ComponentList
{

    public ComponentList(Component[] components)
    {

        _components = components;

    }

    private Component[] _components;

    public T Find<T>()
    {

        T ins = default;

        foreach (var component in _components)
        {

            if (component is T)
            {

                ins = component.Cast<T>();

                return ins;

            }

        }

        return ins;

    }

}