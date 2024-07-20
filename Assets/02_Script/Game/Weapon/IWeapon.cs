using UnityEngine;

public interface IWeapon
{

    public void RotateWeapon(Vector2 dir);
    public void Attack();
    public void SetUp(Transform root);

}