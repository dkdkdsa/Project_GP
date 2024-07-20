using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : ExpansionMonoBehaviour, IItem<IWeaponHandler>, ILocalInject
{

    private IFactory<IWeapon> _weaponFactory;

    public void LocalInject(ComponentList list)
    {

        _weaponFactory = list.Find<IFactory<IWeapon>>();

    }

    public void GetItem(IWeaponHandler targetHandler)
    {

        if (targetHandler == null) return;

        var ins = _weaponFactory.CreateInstance();
        targetHandler.EquipWeapon(ins);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.TryGetComponent<GameTag>(out var compo))
        {

            if(compo.HasTag(Tags.ItemGet))
            {

                GetItem(collision.GetComponent<IWeaponHandler>());

            }

        }

    }

}
