using System;
using System.Collections;
using UnityEngine;

public class IntTimer : MonoBehaviour, ITimer<int>
{

    private Action<int> _timeChangeEvent;
    private Action _timeEndEvent;

    public void RegisterEvent(Action<int> timeChangeCallback)
    {

        _timeChangeEvent += timeChangeCallback;

    }


    public void UnregisterEvent(Action<int> timeChangeCallback)
    {

        _timeChangeEvent -= timeChangeCallback;

    }


    public void StartTimer(int time)
    {

        StartCoroutine(TimerCo(time));

    }

    private IEnumerator TimerCo(int time)
    {

        for(int i = time; i >= 0; i--)
        {

            yield return new WaitForSeconds(1);
            _timeChangeEvent?.Invoke(i);

        }

        Destroy(gameObject);

    }

    private void OnDestroy()
    {

        _timeEndEvent?.Invoke();

    }

    public void RegisterEndEvent(Action endEvent)
    {

        _timeEndEvent += endEvent;

    }

    public void UnregisterEvent(Action endEvent)
    {
        _timeEndEvent -= endEvent;
    }
}