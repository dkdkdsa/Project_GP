using System.Collections.Generic;

public interface IFactory<T> : IFactoryable
{

    public T CreateInstance(PrefabData data = default);

}

public interface IFactoryable { }