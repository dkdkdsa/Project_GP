using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

public static class Support
{
    
    public static int GetHash(this string value)
    {

        return value.GetHashCode();

    }

    public static T Clone<T>(this T source) where T : ICloneable
    {

        return (T)source.Clone();

    }

    public static T Cast<T>(this object source)
    {

        return (T)source;

    }

    public static int GetGameObjectId(this Component comp)
    {

        return comp.gameObject.GetInstanceID();

    }

    public static T GetRandom<T>(this List<T> target)
    {

        return target[Random.Range(0, target.Count)];

    }

    public static ClientRpcParams GetRPCParams(this ulong id, bool targeted = true)
    {

        ClientRpcParams rpcParams = new ClientRpcParams();

        if (targeted)
        {
            rpcParams.Send.TargetClientIds = new[] { id };
        }
        else
        {
            var allClientIds = NetworkManager.Singleton.ConnectedClientsIds;
            rpcParams.Send.TargetClientIds = allClientIds.Where(clientId => clientId != id).ToArray();
        }

        return rpcParams;

    }

}
