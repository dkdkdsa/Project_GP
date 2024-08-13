using System.Collections;
using UnityEngine;

public abstract class GunWeapon : ExpansionMonoBehaviour, IWeapon, ILocalInject
{

    [Header("총기 정보")]
    [SerializeField] private string _bulletPrefabKey;
    [SerializeField] private int _bulletDamage;
    [SerializeField] private int _bulletSpeed;
    [SerializeField] private float _shootDelayTime;
    [SerializeField] private string _prefabKey;
    [Header("손")]
    [SerializeField] private Transform _shootTrm;
    [SerializeField] private Transform[] _hands;

    private IFactory<IBullet> _bulletFactory;
    protected bool _shootDelay;

    public void LocalInject(ComponentList list)
    {

        _bulletFactory = Factory.GetFactory<IBullet>();

    }

    public abstract void Attack(MouseInputType inputType);

    protected void ApplyShootDelay()
    {

        if (_shootDelay) return;

        _shootDelay = true;
        StartCoroutine(ShootDelayCo());

    }

    protected void ShootBullet()
    {

        _bulletFactory.CreateInstance(new PrefabData() { prefabKey = _bulletPrefabKey },
         new BulletDataParam()
         { speed = _bulletSpeed, position = _shootTrm.position, dir = _shootTrm.right, damage = _bulletDamage });

    }

    public void RotateWeapon(Vector2 dir)
    {

        transform.right = dir;
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

        return new PrefabData() { prefabKey = _prefabKey };

    }

    public IEnumerator ShootDelayCo()
    {

        yield return new WaitForSeconds(_shootDelayTime);
        _shootDelay = false;

    }

}
