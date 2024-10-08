using ControllerSystem;
using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class SelectIconTarget : ExpansionMonoBehaviour, ISelectHandler, ILocalInject
{
    public bool IsUsed = true;
    [SerializeField] private Transform _rootTrm = null;

    private IFactory<ISelectIcon> _factory = null;
    private ISelectIcon _icon = null;
    private SelectIconController _controller = null;

    public event Action<SelectIconType> OnShowSelectIconEvent;
    public event Action OnHideSelectIconEvent;

    public void LocalInject(ComponentList list)
    {
        _factory = Factory.GetFactory<ISelectIcon>();
        _controller = Controller.GetController<SelectIconController>();
    }

    public void OnMouseEnter()
    {
        SetShowSelectIconType(_controller.GetSelectIconType());
        ShowSelectIcon();
    }

    public void OnMouseExit()
    {
        HideSelectIcon();
    }
    public void ShowSelectIcon()
    {
        { if (!IsUsed) return; }

        if (_icon != null)
        {
            DoShowSelectIcon();
            OnShowSelectIconEvent?.Invoke(_controller.GetSelectIconType());
        }
    }

    public void HideSelectIcon()
    {
        { if (!IsUsed) return; }

        if (_icon != null)
        {
            DoHideSelectIcon();
            OnHideSelectIconEvent?.Invoke();
        }
    }

    public void DoShowSelectIcon()
    {
        _icon.ShowSelectIcon(_rootTrm);

    }

    public void DoHideSelectIcon()
    {
        _icon.HideSelectIcon();

    }
    public void SetShowSelectIconType(SelectIconType type)
    {
        _icon = _factory.CreateInstance(default, type);
    }




}
