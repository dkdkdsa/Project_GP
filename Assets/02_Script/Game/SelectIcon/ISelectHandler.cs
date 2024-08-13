using System;
using UnityEngine;

public interface ISelectHandler
{
    public event Action<SelectIconType> OnShowSelectIconEvent;
    public event Action OnHideSelectIconEvent;

    public void ShowSelectIcon(Transform trm);
    public void HideSelectIcon();
    public void SetShowSelectIconType(SelectIconType type);
}