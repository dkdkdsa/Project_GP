using System.Collections.Generic;

public interface IFactory<T> : IFactoryable
{

    public List<FactoryData> FactoryDatas { get; set; } 
    public T CreateInstance(PrefabData data);

}

public interface IFactoryable { }