using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IMouseEventHandler : IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// 마우스가 들어왔을때
    /// </summary>
    /// <param name="eventData"></param>
    public abstract void OnPointerEnter(PointerEventData eventData);

    /// <summary>
    /// 마우스로 눌렀을때
    /// </summary>
    /// <param name="eventData"></param>
    public abstract void OnPointerDown(PointerEventData eventData);


    /// <summary>
    /// 마우스가 나갔을때
    /// </summary>
    /// <param name="eventData"></param>
    public abstract void OnPointerExit(PointerEventData eventData);
}
