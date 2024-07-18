using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBody2DProvider : ExpansionMonoBehaviour, IPhysics
{

    private Rigidbody2D _rigid;

    private void Awake()
    {
        
        _rigid = GetComponent<Rigidbody2D>();

    }

    public Vector3 GetVelocity()
    {

        if(_rigid != null)
            return _rigid.velocity;

        Debug.LogError("RigidBody가 Null");
        return Vector3.zero;

    }

    public void SetVelocity(Vector3 val)
    {

        if( _rigid != null)
            _rigid.velocity = val;

    }

}
