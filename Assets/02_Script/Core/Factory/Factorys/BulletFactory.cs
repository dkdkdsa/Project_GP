using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : ExpansionMonoBehaviour, IFactory<IBullet>
{

    private Dictionary<string, GameObject> _prefabContainer = new();

    [field:SerializeField] public List<FactoryData> FactoryDatas { get; set; }

    private void Awake()
    {

        foreach (var factoryData in FactoryDatas)
        {

            _prefabContainer.Add(factoryData.key, factoryData.obj);

        }

    }

    public IBullet CreateInstance(PrefabData data, object extraData = null)
    {

        var ins = _prefabContainer[data.prefabKey];
        var param = extraData.Cast<BulletDataParam>();

        if (ins == null) return null;

        var obj = Instantiate(ins).GetComponent<IBullet>();
        obj.Shoot(param);

        return obj;

    }

}
