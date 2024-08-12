using System;
using UnityEngine;

public interface IMoveable
{

    public event Action<Vector2> OnChangedInputVector;
    public void Move();
    public bool IsRight();
    public void SetInputVector(Vector2 vec);

}
