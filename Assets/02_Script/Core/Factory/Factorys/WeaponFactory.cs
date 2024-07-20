using UnityEngine;

public class WeaponFactory : ExpansionMonoBehaviour, IFactory<IWeapon>
{

    [SerializeField] private GameObject _prefab;

    public IWeapon CreateInstance()
    {

        var ins = Instantiate(_prefab);

        return ins.GetComponent<IWeapon>();

    }

}
