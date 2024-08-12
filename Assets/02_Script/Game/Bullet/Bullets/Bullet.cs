using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ExpansionMonoBehaviour, IBullet, ILocalInject
{

    private IPhysics _physics;

    public void LocalInject(ComponentList list)
    {

        _physics = list.Find<IPhysics>();

    }

    public void Shoot(BulletDataParam param)
    {

        transform.right = param.dir;
        transform.position = param.position;

        _physics.SetVelocity(param.dir * param.speed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        var tag = ObjectManager.Instance.FindGameTag(collision.GetGameObjectId());

        if (tag == null) return;

        if (tag.HasTag(Tags.Hit))
        {

            Destroy(gameObject);

        }

    }

}
