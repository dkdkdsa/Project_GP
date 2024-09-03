/*
* interface: IHitCaster
* Author: 최대원
* Created: 2024년 8월 28일 수요일
* Description: Hit를 케스팅하는 오브젝트들의 추상형
*/

using System;
using Unity.Netcode;
using UnityEngine;

/// <summary>
/// 케스팅 데이터
/// </summary>
[Serializable]
public struct CastData : INetworkSerializable
{

    public Vector2 size;
    public Vector2 pivot;
    public Tags targetTag;
    public float damage;

    public CastData Reverse()
    {

        return new CastData
        {

            size = size,
            pivot = new Vector2(-pivot.x, pivot.y),
            targetTag = targetTag,
            damage = damage

        };

    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {

        serializer.SerializeValue(ref size);
        serializer.SerializeValue(ref pivot);
        serializer.SerializeValue(ref targetTag);
        serializer.SerializeValue(ref damage);

    }

}

/// <summary>
/// Hit를 케스팅하는 오브젝트
/// </summary>
public interface IHitCaster : ITransform
{

    public event Func<CastData, bool> OnCasting;
    public void CastingTargets(in CastData data);
    public void CastingDamage(in CastData data);
    public void CastingKnockback(in CastData data);


}