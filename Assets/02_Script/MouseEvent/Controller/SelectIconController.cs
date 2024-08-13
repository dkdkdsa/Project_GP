using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class SelectIconController : MouseEventController, IMouseEvent<ISelectIcon>
{

    private SelectIconType _type = SelectIconType.None;

    #region Property

    public SelectIconType Type
    {
        get
        {
            return _type;
        }

        set
        {
            if (_type != value)
            {
                _type = value;
                OnChangedType(_type);
            }
        }
    }

    #endregion

    public override void Init()
    {

    }

    public override void OnMouseEnter() 
    {
        base.OnMouseEnter();

        if (hitObject.TryGetComponent<ISelectable>(out var compo))
        {
            compo.SetShowSelectIconType(_type);
        }
    }

    public void ChangedSelectIconType(SelectIconType type)
    {
        _type = type;
    }

    /// <summary>
    /// 타입이 변경되면 호출됨
    /// </summary>
    /// <param name="type"></param>
    private void OnChangedType(SelectIconType type) { }


    public IMouseEvent<ISelectIcon> GetController()
    {
        return this;
    }


}
