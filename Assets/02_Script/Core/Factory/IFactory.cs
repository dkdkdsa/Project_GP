using System.Collections.Generic;

public interface IFactory<T> : IFactoryable
{

    public T CreateInstance(PrefabData data = default, object extraData = null);

}

public interface IFactoryable { }