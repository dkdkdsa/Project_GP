using UnityEngine;

public class ServerBullet : Bullet
{

    private ulong _ownerClientId;

    public void SetOwner(ulong owner)
    {

        _ownerClientId = owner;

    }

    protected override void OnTargetHit(GameTag tag, Vector2 point)
    {

        if (tag.HasTag(Tags.Damageable))
        {

            tag.GetComponent<IDamageable>().TakeDamage(_damage);

            if (tag.TryGetComponent<INetworkObjectController>(out var compo))
            {

                NetworkGameManager.Instance.AttackPlayer(compo.GetOwner(), _ownerClientId);

            }

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
