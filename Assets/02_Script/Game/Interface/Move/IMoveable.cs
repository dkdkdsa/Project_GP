using UnityEngine;

public interface IMoveable
{

    public void Move();
    public bool IsRight();
    public void SetInputVector(Vector2 vec);

}
