using Unity.Netcode;
using UnityEngine;

public struct BulletDataParam : INetworkSerializable
{

    public float speed;
    public float damage;
    public Vector3 position;
    public Vector2 dir;

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {

        serializer.SerializeValue(ref speed);
        serializer.SerializeValue(ref damage);
        serializer.SerializeValue(ref position);
        serializer.SerializeValue(ref dir);

    }

}

public interface IBullet
{

    public void Shoot(BulletDataParam param);

}
