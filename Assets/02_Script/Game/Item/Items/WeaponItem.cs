using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : ExpansionMonoBehaviour, IItem<IWeaponHandler>, ILocalInject
{

    [SerializeField] private string _prefabKey = "Gun";

    private IFactory<IWeapon> _weaponFactory;

    public void LocalInject(ComponentList list)
    {

        _weaponFactory = Factory.GetFactory<IWeapon>();

    }

    public void GetItem(IWeaponHandler targetHandler)
    {

        if (targetHandler == null) return;

        var ins = _weaponFactory.CreateInstance(new PrefabData() { prefabKey = _prefabKey });
        targetHandler.EquipWeapon(ins);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        var tag = ObjectManager.Instance.FindGameTag(collision.GetGameObjectId());

        if (tag == null) return;

        if (tag.TryGetComponent<IPauseable>(out var compo))
            if (compo.IsPaused) return;


        if (tag.HasTag(Tags.ItemGet))
        {

            GetItem(collision.GetComponent<IWeaponHandler>());

        }

    }

}
