using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ExpansionMonoBehaviour, IMoveable, IJumpable, ILocalInject
{

    #region Input

    private readonly int HASH_MOVE_VALUE_KEY = "MoveValue".GetHash();
    private readonly int HASH_JUMP_EVENT_KEY = "JumpEvent".GetHash();

    #endregion

    #region Stat

    private readonly int HASH_MOVESPEED = "MoveSpeed".GetHash();

    #endregion

    private IStatContainer _stat;
    private IPhysics _physics;
    private IInputContainer _input;

    public bool IsPaused { get; set; }

    public void LocalInject(ComponentList list)
    {

        _stat = list.Find<IStatContainer>();
        _physics = list.Find<IPhysics>();
        _input = list.Find<IInputContainer>();

    }

    private void Update()
    {

        Move();

    }

    public void Move()
    {

        _physics.SetVelocity(
            _input.GetValue<Vector2>(HASH_MOVE_VALUE_KEY) 
            * _stat[HASH_MOVESPEED].Value);

    }

    public void Jump()
    {



    }


    public void DoPause()
    {

        _physics.SetVelocity(Vector3.zero);

    }

    public void DoResume()
    {



    }

}