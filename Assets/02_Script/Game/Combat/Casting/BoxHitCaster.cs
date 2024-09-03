using System.Collections.Generic;
using UnityEngine;

public class BoxHitCaster : ExpansionMonoBehaviour, IHitCaster
{

    public void CastingTargets(in CastData data)
    {

        var hits = Casting(data);

        foreach (var tag in hits)
        {

            if (tag.HasTag(Tags.Damageable))
            {

                tag.GetComponent<IDamageable>().TakeDamage(data.damage);

            }

            if (tag.HasTag(Tags.KnockBackable))
            {

                var hp = tag.GetComponent<IHp>();

                tag.GetComponent<IKnockBackable>()
                .KnockBack(IKnockBackable.CalculateKnockBackForce(data.damage,
                1 + Mathf.InverseLerp(0, hp.GetMaxHp(), hp.GetHp())), (tag.transform.position - transform.position).normalized);

            }

        }

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

                    if (compo.HasTag(data.targetTag))
                    {

                        arr.Add(compo);

                    }

                }

            }

        }

        return null;

    }

}