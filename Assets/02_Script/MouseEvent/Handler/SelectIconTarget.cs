using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LocalInstaller))]
public class SelectIconTarget : MouseEventHandler, ISelectable, ILocalInject
{
    [SerializeField] private Transform _rootTrm = null;
    private IFactory<ISelectIcon> _factory = null;
    private ISelectIcon _icon = null;
    public void LocalInject(ComponentList list)
    {
        _factory = Factory.GetFactory<ISelectIcon>();
    }

    public void SetShowSelectIconType(SelectIconType type)
    {   
        _icon = _factory.CreateInstance(default, type);
    }

    public override void OnMouseEnter()
    {
        { if (!IsUsed) return; }

        SetShowSelectIconType(SelectIconType.Box);

        if (_icon != null)
        {
            _icon.ShowSelectIcon(_rootTrm);
        }
    }

    public override void OnMouseExit()
    {
        { if (!IsUsed) return; }

        if (_icon != null)
        {
            _icon.HideSelectIcon();
        }
    }
}
