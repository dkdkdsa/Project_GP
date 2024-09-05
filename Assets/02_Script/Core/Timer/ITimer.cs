using System;

public interface ITimer<T>
{

    public void RegisterEvent(Action<T> timeChangeCallback);
    public void RegisterEndEvent(Action endEvent);
    public void UnregisterEvent(Action<T> timeChangeCallback);
    public void UnregisterEvent(Action endEvent);
    public void StartTimer(T time);

}