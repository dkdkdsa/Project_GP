using System;

public class PlayerDie : ExpansionMonoBehaviour, IDieable, IPauseable
{
    public bool IsPaused { get; set; }

    public event Action OnDieEvent;

    public void Die()
    {

        if (IsPaused) return;

        OnDieEvent?.Invoke();

    }

    public void DoPause()
    {
    }

    public void DoResume()
    {
    }

}