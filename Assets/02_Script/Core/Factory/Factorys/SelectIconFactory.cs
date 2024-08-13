using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectIconFactory : ExpansionMonoBehaviour, IFactory<ISelectIcon>
{
    private Dictionary<SelectIconType, GameObject> _prefabContainer = new();

    [field: SerializeField] public List<SelectIconData> FactoryDatas { get; set; }

    private void Awake()
    {

        foreach (var factoryData in FactoryDatas)
        {

            _prefabContainer.Add(factoryData.Type, factoryData.Obj);

        }

    }

    public ISelectIcon CreateInstance(PrefabData data, object extraData = null)
    {
        var iconEnum = extraData.Cast<SelectIconType>();
        var ins = _prefabContainer[iconEnum];

        if (ins == null) return null;

        var obj = Instantiate(ins).GetComponent<ISelectIcon>();

        return obj;

    }
}
