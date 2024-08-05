using UnityEngine;

public class GunWeapon : ExpansionMonoBehaviour, IWeapon, ILocalInject
{

    [SerializeField] private Transform _shootTrm;
    [SerializeField] private Transform[] _hands;

    private IFactory<IBullet> _bulletFactory;

    public void LocalInject(ComponentList list)
    {

        _bulletFactory = list.Find<IFactory<IBullet>>();

    }

    public void Attack()
    {

        var blt = _bulletFactory.CreateInstance();

        blt.Shoot(_shootTrm.right, new() { speed = 3, position = _shootTrm.position });

    }

    public void RotateWeapon(Vector2 dir)
    {

        transform.right = dir;
        transform.localScale = GetScale(dir);

    }

    private Vector3 GetScale(Vector2 dir)
    {

        return dir.x > 0 ? Vector3.one : new Vector3(1, -1, 1);

    }

    public void SetUp(Transform root)
    {

        transform.SetParent(root);
        transform.localPosition = Vector3.zero;

    }

    public void Release()
    {

        Destroy(gameObject);

    }

    public Transform[] GetHandPos()
    {

        return _hands;

    }

    public PrefabData GetPrefabData()
    {

        return new PrefabData() { prefabKey = "Gun" };

    }

}
