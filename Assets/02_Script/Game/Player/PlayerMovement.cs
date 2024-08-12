using System;
using UnityEngine;

public class PlayerMovement : ExpansionMonoBehaviour, 
    IMoveable, IJumpable, ILocalInject, IPauseable, IKnockBackable
{

    #region Input

    private readonly int HASH_MOVE_VALUE_KEY = "MoveValue".GetHash();
    private readonly int HASH_JUMP_EVENT_KEY = "JumpEvent".GetHash();

    #endregion

    #region Stat

    private readonly int HASH_MOVESPEED = "MoveSpeed".GetHash();
    private readonly int HASH_JUMOPPOWER = "JumpPower".GetHash();

    #endregion

    private IInputContainer _input;
    private IStatContainer _stat;
    private IPhysics _physics;
    private ISencer _ground;
    private Vector2 _inputVec;
    private bool _isRight;

    public event Action<Vector2> OnChangedInputVector;

    public bool IsPaused { get; set; }

    public void LocalInject(ComponentList list)
    {

        _input = list.Find<IInputContainer>();
        _stat = list.Find<IStatContainer>();
        _physics = list.Find<IPhysics>();
        _ground = list.Find<ISencer>();

        _input.RegisterEvent(HASH_JUMP_EVENT_KEY, Jump);

    }

    private void Update()
    {

        if (IsPaused) return;

        SetInputVector(_input.GetValue<Vector2>(HASH_MOVE_VALUE_KEY));

        Move();

    }

    public void Move()
    {

        var vel = _physics.GetVelocity();
        var y = vel.y;

        vel = _inputVec
            * _stat[HASH_MOVESPEED].Value;

        vel.y = y;

        _physics.SetVelocity(vel);

    }

    public void Jump()
    {

        if (IsPaused) return;

        if (_ground.IsSencing())
        {

            _physics.AddFource(Vector2.up * _stat[HASH_JUMOPPOWER].Value);

        }

    }


    public void DoPause()
    {

        _physics.SetVelocity(Vector3.zero);

    }

    public void DoResume()
    {

    }

    private void OnDestroy()
    {

        if (_input != null)
        {

            _input.UnregisterEvent(HASH_JUMP_EVENT_KEY, Jump);

        }

    }

    public bool IsRight()
    {

        _isRight = _inputVec.x switch 
        { 

            > 0 => true,
            < 0 => false,
            _ => _isRight, 

        };

        return _isRight;

    }

    public void SetInputVector(Vector2 vec)
    {

        if (_inputVec == vec)
            return;

        _inputVec = vec;
        OnChangedInputVector?.Invoke(vec);

    }

    public void KnockBack(float force)
    {

        _physics.AddFource(-_inputVec + Vector2.up);

    }

}