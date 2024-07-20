using UnityEngine;

public struct BulletDataParam
{

    public float speed;
    public float damage;

}

public interface IBullet
{

    public void Shot(Vector2 dir, BulletDataParam param);

}
