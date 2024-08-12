using System;

public interface IDieable
{

    public event Action OnDieEvent;
    public void Die();

}