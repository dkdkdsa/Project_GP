using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ExpansionMonoBehaviour, IBullet, ILocalInject
{

    protected IPhysics _physics;
    protected float _damage;

    public void LocalInject(ComponentList list)
    {

        _physics = list.Find<IPhysics>();

    }

    public void Shoot(BulletDataParam param)
    {

        transform.right = param.dir;
        transform.position = param.position;

        _physics.SetVelocity(param.dir * param.speed);
        _damage = param.damage;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        var tag = ObjectManager.Instance.FindGameTag(collision.GetGameObjectId());

        if (tag == null) return;

        if (tag.HasTag(Tags.Hit))
        {

            OnTargetHit(tag, tag.transform.position);
            Destroy(gameObject);

        }

    }

    protected virtual void OnTargetHit(GameTag tag, Vector2 point)
    {
    }

}
