using Unity.Netcode.Components;
using UnityEngine;

public class Player : ExpansionMonoBehaviour, ILocalInject, IHp, IDamageable
{

    private readonly int HASH_MAX_HP = "MaxHp".GetHash();

    private IKnockBackable _knockBack;
    private IStatContainer _stat;
    private float _currentHp;

    public void LocalInject(ComponentList list)
    {

        _stat = list.Find<IStatContainer>();
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

        return _stat[HASH_MAX_HP].Value;

    }

}