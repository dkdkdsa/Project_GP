using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkBulletFactory : ExpansionNetworkBehaviour, IFactory<IBullet>
{

    [SerializeField] private GameObject _serverBullet;

    private Dictionary<string, GameObject> _prefabContainer = new();

    [field: SerializeField] public List<FactoryData> FactoryDatas { get; set; }

    private void Awake()
    {

        foreach (var factoryData in FactoryDatas)
        {

            _prefabContainer.Add(factoryData.key, factoryData.obj);

        }

    }

    public IBullet CreateInstance(PrefabData data = default, object extraData = null)
    {

        var param = extraData.Cast<BulletDataParam>();
        var obj = CreateBullet(data, param);

        ShootBulletServerRPC(data, param, NetworkManager.LocalClientId);

        return obj;
    }

    private IBullet CreateBullet(PrefabData data, BulletDataParam param)
    {

        var ins = _prefabContainer[data.prefabKey];

        if (ins == null) return null;

        var obj = Instantiate(ins).GetComponent<IBullet>();
        obj.Shoot(param);

        return obj;

    }

    [ServerRpc(RequireOwnership = false)]
    private void ShootBulletServerRPC(PrefabData prefabData, BulletDataParam data, ulong shootClient)
    {

        var blt = Instantiate(_serverBullet).GetComponent<ServerBullet>();
        blt.Shoot(data);
        blt.SetOwner(shootClient);

        ShootBulletClientRPC(prefabData, data, shootClient.GetRPCParams(false));

    }

    [ClientRpc]
    private void ShootBulletClientRPC(PrefabData prefabData, BulletDataParam bulletData, ClientRpcParams @params)
    {

        CreateBullet(prefabData, bulletData);

    }

}
