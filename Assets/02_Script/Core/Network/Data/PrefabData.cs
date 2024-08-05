using Unity.Netcode;

public struct PrefabData : INetworkSerializable
{

    public string prefabKey;

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {

        serializer.SerializeValue(ref prefabKey);

    }

}