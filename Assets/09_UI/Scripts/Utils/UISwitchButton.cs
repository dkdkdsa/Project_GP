using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UISwitchButton : UIComponent
{
    public bool IsPressed = false;

    public UnityEvent<bool> OnPressedEvent = null;

    public UnityEvent OnSwitchEvent = null;
    public UnityEvent UnSwitchEvent = null;

    public void OnPressButton()
    {
        IsPressed = !IsPressed;
        OnPressedEvent?.Invoke(IsPressed);

        Modify();
    }

    private void Modify()
    {
        if (IsPressed) OnSwitchEvent?.Invoke();
        else UnSwitchEvent?.Invoke();
    }
}
