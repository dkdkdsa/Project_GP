public class ComponentList
{

    public ComponentList(IComponent[] components)
    {

        _components = components;

    }

    private IComponent[] _components;

    public T Find<T>() where T : IComponent
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