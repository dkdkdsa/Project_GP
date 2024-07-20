using UnityEngine;

public interface IWeapon : ITransform
{

    public void RotateWeapon(Vector2 dir);
    public void Attack();

}