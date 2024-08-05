using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : ExpansionMonoBehaviour, IFactory<IWeapon>
{

    private Dictionary<string, GameObject> _prefabContainer = new();

    [field:SerializeField] public List<FactoryData> FactoryDatas { get; set; }

    private void Awake()
    {
        
        foreach(var factoryData in FactoryDatas)
        {

            _prefabContainer.Add(factoryData.key, factoryData.obj);

        }

    }

    public IWeapon CreateInstance(PrefabData data)
    {

        var ins = _prefabContainer[data.prefabKey];

        if (ins == null) return null;

        var obj = Instantiate(ins).GetComponent<IWeapon>();

        return obj;

    }

}
