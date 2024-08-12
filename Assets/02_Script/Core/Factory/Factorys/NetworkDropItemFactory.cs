using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkDropItemFactory : ExpansionMonoBehaviour, IFactory<IItem>
{

    [SerializeField] private List<NetworkObject> _prefabTable; 

    public IItem CreateInstance(PrefabData data = default, object extraData = null)
    {

        var pivot = extraData.Cast<Transform>();

        Instantiate(_prefabTable.GetRandom(), GetRandomPos(pivot), Quaternion.identity)
            .GetComponent<NetworkObject>().Spawn(true);

        return null; //뭘 리턴하든 상관 ㄴ

    }

    private Vector3 GetRandomPos(Transform pivot)
    {

        return new Vector3(pivot.position.x + Random.Range(-5, 5), pivot.position.y);

    }

}
