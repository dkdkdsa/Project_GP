using UnityEngine;

public class ServerBullet : Bullet
{

    protected override void OnTargetHit(GameTag tag, Vector2 point)
    {

        if (tag.HasTag(Tags.Damageable))
        {

            tag.GetComponent<IDamageable>().TakeDamage(_damage);

        }

        if (tag.HasTag(Tags.KnockBackable))
        {

            var hp = tag.GetComponent<IHp>();

            tag.GetComponent<IKnockBackable>()
            .KnockBack(IKnockBackable.CalculateKnockBackForce(_damage,
            1 + Mathf.InverseLerp(0, hp.GetMaxHp(), hp.GetHp())), (tag.transform.position - transform.position).normalized);

        }

    }

}
