using System;
using UnityEngine;

public interface IWeapon
{

    public void RotateWeapon(Vector2 dir);
    public void Attack();
    public void SetUp(Transform root);
    public void Release();
    public Transform[] GetHandPos();
    public PrefabData GetPrefabData();

}