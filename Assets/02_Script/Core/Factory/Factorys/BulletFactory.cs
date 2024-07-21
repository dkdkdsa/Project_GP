using UnityEngine;

public class BulletFactory : ExpansionMonoBehaviour, IFactory<IBullet>
{

    [SerializeField] private GameObject _bullet;

    public IBullet CreateInstance()
    {

        var blt = Instantiate(_bullet);
        return blt.GetComponent<IBullet>();

    }

}
