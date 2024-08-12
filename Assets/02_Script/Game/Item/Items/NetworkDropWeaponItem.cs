public class NetworkDropWeaponItem : NetworkDropItem<IWeaponHandler>, ILocalInject
{

    private IFactory<IWeapon> _weaponFactory;

    public void LocalInject(ComponentList list)
    {

        _weaponFactory = Factory.GetFactory<IWeapon>();

    }

    public override void GetItem(IWeaponHandler targetHandler)
    {

        targetHandler
            .EquipWeapon(_weaponFactory.CreateInstance(new() { prefabKey = _prefabKey }));

    }

}
