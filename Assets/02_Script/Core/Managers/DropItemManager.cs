using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemManager : MonoSingleton<DropItemManager>, ILocalInject
{

    [SerializeField] private float _minSpawnTime = 30, _maxSpawnTime = 45;
    [SerializeField] private Transform _itemSpawnPivot;

    private IFactory<IItem> _itemFactory;

    public void LocalInject(ComponentList list)
    {

        _itemFactory = Factory.GetFactory<IItem>();

    }

    public void StartDrop()
    {

        StartCoroutine(DropItemLogic());

    }


    private void SpawnItem()
    {

        _itemFactory.CreateInstance(default, _itemSpawnPivot);

    }

    private IEnumerator DropItemLogic()
    {

        while (true)
        {

            SpawnItem();
            yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));

        }

    }

}