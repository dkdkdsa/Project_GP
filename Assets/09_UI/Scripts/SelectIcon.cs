using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LocalInstaller))]
[RequireComponent(typeof(SpriteRendererProvider))]
public abstract class SelectIcon : ExpansionMonoBehaviour, ISelectIcon, ILocalInject
{
    [Tooltip("커지고 작아지는 시간")]
    public float Duration = 0.3f;

    [Tooltip("두께")]
    public float Thickness = 0.2f;

    private IRenderer _renderer;
    private Coroutine _coroutine;

    public void LocalInject(ComponentList list)
    {
        _renderer = list.Find<IRenderer>();
    }

    public virtual void ShowSelectIcon(Transform rootTrm)
    {
        transform.parent = rootTrm;
        transform.localPosition = Vector3.zero;

        //처음엔 0,0으로 초기화
        _renderer.SetSpriteSize(0f, 0f);

        float endX = rootTrm.localScale.x + Thickness;
        float endY = rootTrm.localScale.y + Thickness;

        if (_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(LerpSelectBoxSize(endX, endY, Duration));
    }

    public virtual void HideSelectIcon(float duration = 0.3f)
    {
        transform.parent = null;

        if (_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(LerpSelectBoxSize(0f, 0f, duration));

        Destroy(gameObject, duration);
    }

    private IEnumerator LerpSelectBoxSize(float width, float height, float duration)
    {
        (float startX, float startY) = _renderer.GetSpriteSize();

        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            float currentX = Mathf.Lerp(startX, width, t);
            float currentY = Mathf.Lerp(startY, height, t);

            _renderer.SetSpriteSize(currentX, currentY);
            yield return null;
        }

        _renderer.SetSpriteSize(width, height);
    }
}
