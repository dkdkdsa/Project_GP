using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MouseEventHandler : ExpansionMonoBehaviour
{   
    public bool IsUsed = true;

    public abstract void OnMouseEnter();
    public abstract void OnMouseExit();
    public abstract void OnMouseDown();
}
