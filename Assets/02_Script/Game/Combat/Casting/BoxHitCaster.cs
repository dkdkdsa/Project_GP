using System;
using System.Collections.Generic;
using UnityEngine;

public class BoxHitCaster : ExpansionMonoBehaviour, IHitCaster
{

    private GameTag _tag;

    public event Func<CastData, bool> OnCasting;

    private void Awake()
    {
        
        _tag = GetComponent<GameTag>();

    }

    public void CastingDamage(in CastData data, Action<GameObject> hitCallback = null)
    {

        var hits = Casting(data);

        if (hits == null)
            return;

        foreach (var tag in hits)
        {

            if (tag.HasTag(Tags.Damageable))
            {

                tag.GetComponent<IDamageable>().TakeDamage(data.damage);
                hitCallback?.Invoke(tag.gameObject);

            }

        }

    }

    public void CastingKnockback(in CastData data)
    {

        var hits = Casting(data);

        if (hits == null)
            return;

        foreach (var tag in hits)
        {

            if (tag.HasTag(Tags.KnockBackable))
            {

                var hp = tag.GetComponent<IHp>();

                tag.GetComponent<IKnockBackable>()
                .KnockBack(IKnockBackable.CalculateKnockBackForce(data.damage,
                1 + Mathf.InverseLerp(0, hp.GetMaxHp(), hp.GetHp())), (tag.transform.position - transform.position).normalized);

            }

        }
    }

    public void CastingTargets(in CastData data)
    {

        if(OnCasting != null)
            if(!OnCasting(data))
                return;

        Debug.Log(1);

        CastingDamage(in data);
        CastingTargets(in data);

    }

    public Transform GetTransform()
    {

        return transform;

    }

    private List<GameTag> Casting(in CastData data)
    {

        var objs = Physics2D.OverlapBoxAll(transform.position + (Vector3)data.pivot, data.size, 0);
        
        if (objs.Length > 0)
        {

            List<GameTag> arr = new();

            foreach (var obj in objs)
            {

                if (obj.TryGetComponent<GameTag>(out var compo))
                {

                    if (_tag == compo)
                        continue;

                    if (compo.HasTag(data.targetTag))
                    {

                        arr.Add(compo);

                    }

                }

            }

            return arr;

        }

        return null;

    }

}