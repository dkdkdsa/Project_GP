using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DefancePanel : UIComponent, IUIMouseEventHandler
{
    public UnityEvent OnClickEvent = null;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnClickEvent?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
