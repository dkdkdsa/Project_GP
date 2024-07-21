using UnityEngine;

public struct BulletDataParam
{

    public float speed;
    public float damage;
    public Vector3 position;

}

public interface IBullet
{

    public void Shoot(Vector2 dir, BulletDataParam param);

}
