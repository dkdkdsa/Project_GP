using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ExpansionMonoBehaviour, IMoveable, IJumpable, ILocalInject
{

    private readonly int HASH_MOVESPEED = "MoveSpeed".GetHash();

    private IStatContainer _statContainer;
    private IPhysics _physics;
    private IInputContainer _input;

    public bool IsPaused { get; set; }

    public void LocalInject(ComponentList list)
    {

        _statContainer = list.Find<IStatContainer>();
        _physics = list.Find<IPhysics>();
        _input = list.Find<IInputContainer>();

    }

    public void Move()
    {



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