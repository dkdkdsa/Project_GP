using System;
using UnityEngine;

public interface IKnockBackable
{

    public event Action<float, Vector2> OnKnockBackEvent;

    public void KnockBack(float force, Vector2 dir);

    public static float CalculateKnockBackForce(float damage, float hpPer)
    {

        return Mathf.Clamp(damage, 0f, 10f) * hpPer;

    }

}