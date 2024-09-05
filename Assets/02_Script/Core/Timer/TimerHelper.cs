using UnityEngine;

public static class TimerHelper
{

    public static ITimer<T> StartTimer<T, TCompo>(T time) where TCompo : Component, ITimer<T>
    {

        var obj = new GameObject();
        var timer = obj.AddComponent<TCompo>();
        timer.StartTimer(time);

        return timer;

    }

}
