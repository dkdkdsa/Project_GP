using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class SelectIconController : ExpansionMonoBehaviour, IController<ISelectIcon>
{

    private SelectIconType _type = SelectIconType.None;
    public Action<SelectIconType> OnChangedTypeEvent = null;

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

                OnChangedTypeEvent?.Invoke(_type);
                OnChangedType(_type);
            }
        }
    }

    #endregion

    public void Init()
    {
        //임시
        ChangedSelectIconType(SelectIconType.Box);
    }

    public SelectIconType GetSelectIconType()
    {
        return _type;
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


    public IController<ISelectIcon> GetController()
    {
        return this;
    }


}
