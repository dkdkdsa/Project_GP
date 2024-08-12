using UnityEngine;

public class GunWeapon : ExpansionMonoBehaviour, IWeapon, ILocalInject
{

    [SerializeField] private Transform _shootTrm;
    [SerializeField] private Transform[] _hands;

    private IFactory<IBullet> _bulletFactory;

    public void LocalInject(ComponentList list)
    {

        _bulletFactory = Factory.GetFactory<IBullet>();

    }

    public void Attack()
    {

        _bulletFactory.CreateInstance(new PrefabData() { prefabKey = "" }, 
            new BulletDataParam () 
        { speed = 3, position = _shootTrm.position, dir = _shootTrm.right });

    }

    public void RotateWeapon(Vector2 dir)
    {

        transform.parent.right = dir;
        transform.parent.localScale = GetScale(dir);

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
