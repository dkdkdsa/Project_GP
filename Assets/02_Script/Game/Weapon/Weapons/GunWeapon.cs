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
        transform.localScale = GetScale(dir);

    }

    private Vector3 GetScale(Vector2 dir)
    {

        return dir.x > 0 ? Vector3.one : new Vector3(1, -1, 1);

    }

    public void SetUp(Transform root)
    {

        transform.SetParent(root);
        transform.localPosition = Vector3.zero;

    }

}
