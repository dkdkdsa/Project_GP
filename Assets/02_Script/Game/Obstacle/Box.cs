using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Box : ObstacleComponent, ILocalInject, IHp, IDamageable
{
    private readonly int HASH_MAX_HP = "MaxHp".GetHash();


    public float HaxHp = 10;
    public UnityEvent OnDiedEvent = null;

    private IKnockBackable _knockBack;
    private float _currentHp;

    public void LocalInject(ComponentList list)
    {
        _knockBack = list.Find<IKnockBackable>();
    }

    private void Awake()
    {

        _currentHp = GetMaxHp();

    }

    public void SetHp(float hp)
    {

        _currentHp = hp;

    }


    public void AddHp(float hp)
    {

        _currentHp += hp;

    }


    public void SubtractHp(float hp)
    {

        _currentHp -= hp;
        _currentHp = Mathf.Clamp(_currentHp, 0, GetMaxHp());


        if (_currentHp <= 0)
        {
            OnDiedEvent?.Invoke();
        }


    }

    public void TakeDamage(float damage)
    {

        SubtractHp(damage);

    }


    public float GetHp()
    {

        return _currentHp;

    }

    public float GetMaxHp()
    {

        return HaxHp;

    }
}
