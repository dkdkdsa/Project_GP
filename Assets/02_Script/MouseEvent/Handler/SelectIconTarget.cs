using ControllerSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NetworkSelectIconTarget))]
[RequireComponent(typeof(LocalInstaller))]
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
        _controller = Controller.GetController<ISelectIcon>().Cast<SelectIconController>();
    }

    public void OnMouseEnter()
    {
        SetShowSelectIconType(_controller.GetSelectIconType());
        ShowSelectIcon(_rootTrm);
    }

    public void OnMouseExit()
    {
        HideSelectIcon();
    }


    public void ShowSelectIcon(Transform trm)
    {
        { if (!IsUsed) return; }

        if (_icon != null)
        {
            _icon.ShowSelectIcon(_rootTrm);
            OnShowSelectIconEvent?.Invoke(_controller.GetSelectIconType());
        }
    }

    public void HideSelectIcon()
    {
        { if (!IsUsed) return; }

        if (_icon != null)
        {
            _icon.HideSelectIcon();
            OnHideSelectIconEvent?.Invoke();
        }
    }
    public void SetShowSelectIconType(SelectIconType type)
    {
        _icon = _factory.CreateInstance(default, type);
    }
}
