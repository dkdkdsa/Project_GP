using UnityEngine;

public interface IWeapon
{

    public void RotateWeapon(Vector2 dir);
    public void Attack(MouseInputType inputType);
    public void SetUp(Transform root);
    public void Release();
    public Transform[] GetHandPos();
    public PrefabData GetPrefabData();

}