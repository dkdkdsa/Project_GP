using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToTakeDamage : MonoBehaviour
{
    public float Damage = 10;

    private IDamageable _target;

    private void Awake()
    {
        _target = GetComponent<IDamageable>();
    }

    private void OnMouseDown()
    {
        _target.TakeDamage(Damage);
    }
}
