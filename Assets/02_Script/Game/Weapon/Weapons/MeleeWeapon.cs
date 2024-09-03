using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : ExpansionMonoBehaviour, IWeapon
{

    [Header("생성 키")]
    [SerializeField] private string _prefabKey;
    [Header("피격 데이터")]
    [SerializeField] private CastData _data;
    [Header("공격")]
    [SerializeField] private float _rotateAngle;
    [SerializeField] private float _attackCoolDown;
    [Header("손")]
    [SerializeField] private Transform[] _hands;

    private IHitCaster _hitCaster;
    private IRenderer _renderer;
    private bool _isAttackFirstDel; //공격 선딜
    private bool _isAttack;


    public void Attack(MouseInputType inputType)
    {

        if(_isAttack) return;

        var data = _renderer.GetFlip().x ? _data.Reverse() : _data;

        _hitCaster.CastingTargets(in data);
        StartCoroutine(CoolDownCo());

    }

    public Transform[] GetHandPos()
    {

        return _hands;

    }


    public void RotateWeapon(Vector2 dir)
    {

        transform.parent.localEulerAngles = GetAngle();
        transform.parent.localScale = GetScale();

    }

    private Vector3 GetAngle()
    {

        float z = _isAttackFirstDel ?
            _renderer.GetFlip().x ?
            _rotateAngle : -_rotateAngle
            :
            0;

        return new Vector3(0, 0, z);

    }

    public void SetUp(Transform root)
    {

        _hitCaster = root.root.GetComponent<IHitCaster>();
        _renderer = root.root.GetComponent<IRenderer>();

        transform.SetParent(root);
        transform.localPosition = Vector3.zero;

    }

    public void Release()
    {



    }

    private IEnumerator CoolDownCo()
    {

        _isAttackFirstDel = true;
        yield return new WaitForSeconds(0.2f);
        _isAttackFirstDel = false;

        _isAttack = true;
        yield return new WaitForSeconds(_attackCoolDown);
        _isAttack = false;

    }

    private Vector3 GetScale() => !_renderer.GetFlip().x? Vector3.one : new Vector3(-1, 1, 1);
    public PrefabData GetPrefabData() => new PrefabData { prefabKey = _prefabKey };

}
