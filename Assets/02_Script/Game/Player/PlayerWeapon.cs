using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : ExpansionMonoBehaviour, ILocalInject, IWeaponHandler, IPauseable
{

    private readonly int HASH_ATTACK_EVENT_KEY = "AttackEvent".GetHash();
    private readonly int HASH_MOUSE_POS_KEY = "MousePos".GetHash();

    [SerializeField] private Transform _weaponRoot;

    private Camera _cam;
    private IInputContainer _input;
    private IWeapon _weapon;

    public bool IsPaused { get; set; }

    public void LocalInject(ComponentList list)
    {

        _input = list.Find<IInputContainer>();

        _input.RegisterEvent(HASH_ATTACK_EVENT_KEY, AttackWeapon);

        _cam = Camera.main;

    }

    private void Update()
    {

        if (IsPaused) return;

        RotateWeapon();

    }

    public void EquipWeapon(IWeapon weapon)
    {

        if(_weapon != null)
        {

            _weapon.Release();

        }

        _weapon = weapon;
        _weapon.SetUp(_weaponRoot);

    }

    public void UnEquipWeapon()
    {

        _weapon = null;

    }

    public void AttackWeapon()
    {

        if (_weapon == null) return;

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