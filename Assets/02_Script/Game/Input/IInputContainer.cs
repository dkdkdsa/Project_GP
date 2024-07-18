using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputContainer
{

    public void RegisterEvent(int key, Action @event);
    public void UnregisterEvent(int key, Action @event);
    public T GetValue<T>(int key) where T : struct;

}