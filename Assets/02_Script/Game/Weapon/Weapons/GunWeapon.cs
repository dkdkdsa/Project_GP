using UnityEngine;

public class GunWeapon : ExpansionMonoBehaviour, IWeapon
{

    public void Attack()
    {

        Debug.Log("Attack");

    }

    public void RotateWeapon(Vector2 dir)
    {

        transform.right = dir;

    }

    public void SetUp(Transform root)
    {

        transform.SetParent(root);

    }

}
