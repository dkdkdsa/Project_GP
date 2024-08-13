using UnityEngine;

public interface ISelectIcon
{
    public void ShowSelectIcon(Transform rootTrm);

    public void HideSelectIcon(float duration = 0.3f);
}