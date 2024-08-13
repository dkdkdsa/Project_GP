using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : ExpansionMonoBehaviour, ILocalInject, IWeaponHandler, IPauseable
{

    private readonly int HASH_ATTACK_EVENT_KEY = "AttackEvent".GetHash();
    private readonly int HASH_MOUSE_POS_KEY = "MousePos".GetHash();

    [SerializeField] private Transform _weaponRoot;

    private IHandController _handController;
    private IInputContainer _input;
    private IWeapon _weapon;
    private Camera _cam;

    public event Action<PrefabData> OnEquipWeaponEvent;
    public event Action OnUnEquipWeaponEvent;
    public event Action OnAttackWeaponEvent;
    public bool IsPaused { get; set; }

    public virtual void LocalInject(ComponentList list)
    {

        _input = list.Find<IInputContainer>();
        _handController = list.Find<IHandController>();

        _input.RegisterEvent(HASH_ATTACK_EVENT_KEY, AttackWeapon);

        _cam = Camera.main;

    }

    private void Update()
    {

        if (IsPaused) return;

        RotateWeapon();

    }

    public virtual void EquipWeapon(IWeapon weapon)
    {

        OnEquipWeaponEvent?.Invoke(weapon.GetPrefabData());

        if(_weapon != null)
        {

            _weapon.Release();

        }

        _weaponRoot.transform.right = Vector2.right;
        _weaponRoot.transform.localScale = Vector3.one;

        _weapon = weapon;
        _weapon.SetUp(_weaponRoot);
        _handController.SetUpHandPos(_weapon.GetHandPos());

    }

    public virtual void UnEquipWeapon()
    {

        OnUnEquipWeaponEvent?.Invoke();

        _weapon = null;

    }

    public virtual void AttackWeapon()
    {

        if (_weapon == null) return;

        OnAttackWeaponEvent?.Invoke();

        _weapon.Attack();

    }

    public void RotateWeapon()
    {

        if (_weapon == null) return;

        var pos = _cam.ScreenToWorldPoint(_input.GetValue<Vector2>(HASH_MOUSE_POS_KEY));

        var dir = pos - _weaponRoot.position;

        _weapon.RotateWeapon(dir);

    }

    public void DoPause()
    {
    }

    public void DoResume()
    {
    }

    private void OnDestroy()
    {
        
        if(_input != null)
        {

            _input.UnregisterEvent(HASH_ATTACK_EVENT_KEY, AttackWeapon);

        }

    }

}