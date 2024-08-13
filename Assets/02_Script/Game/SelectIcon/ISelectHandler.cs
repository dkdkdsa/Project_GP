using System;
using UnityEngine;

public interface ISelectHandler
{
    public event Action<SelectIconType> OnShowSelectIconEvent;
    public event Action OnHideSelectIconEvent;

    public void ShowSelectIcon();
    public void DoShowSelectIcon();
    public void HideSelectIcon();
    public void DoHideSelectIcon();
    public void SetShowSelectIconType(SelectIconType type);
}