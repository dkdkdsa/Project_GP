public class ServerBullet : Bullet
{

    protected override void OnTargetHit(GameTag tag)
    {

        if (tag.HasTag(Tags.Damageable))
        {

            tag.GetComponent<IDamageable>().TakeDamage(_damage);

        }

    }

}
